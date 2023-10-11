using System;
using System.Data;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Record;

namespace Excel2Wiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //enable drag and drop
            this.AllowDrop = true;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                ImportFile(openFileExcel.FileName);
            }
        }

        //this function just check if the line is empty
        private bool IsRowEmpty(IRow row)
        {
            if (row == null) return true;

            foreach (ICell cell in row)
            {
                if (cell != null && !string.IsNullOrWhiteSpace(cell.ToString()))
                {
                    return false;
                }
            }
            return true;
        }


        private void ImportFile(string fullpath)
        {
            IWorkbook workbook;
            ISheet sheet;

            using (var fileStream = new System.IO.FileStream(fullpath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                if (fullpath.EndsWith(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fileStream); // Per file .xlsx
                }
                else if (fullpath.EndsWith(".xls"))
                {
                    workbook = new HSSFWorkbook(fileStream); // Per file .xls
                }
                else
                {
                    throw new Exception("Unsupported file type");
                }

                int numberOfSheets = workbook.NumberOfSheets;
                if (numberOfSheets > 1)
                {
                    MessageBox.Show("Warning, preadsheet document contains more than 1 sheet. Only first will be considered", "Warning, possible data loss", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                sheet = workbook.GetSheetAt(0);
            }

            //I have the data. Let's clean the grid
            dgWikiTable.Rows.Clear();
            dgWikiTable.Columns.Clear();

            //start working on data
            DataTable dt = new DataTable();

            // Aggiungi le intestazioni delle colonne
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            //add columns with no names
            for (int i = 0; i < cellCount; i++)
            {
                dgWikiTable.Columns.Add("", "");
            }

            // add the rows
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);

                // Se il checkbox è selezionato e la riga è vuota, continua al prossimo ciclo
                if (chkSkipBlankLines.Checked && IsRowEmpty(row))
                {
                    continue;
                }

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgWikiTable);

                for (int j = 0; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        // Qui puoi aggiungere la tua logica personalizzata
                        newRow.Cells[j].Value = row.GetCell(j).ToString();
                    }
                }

                dgWikiTable.Rows.Add(newRow);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void DoExit()
        {
            //add stuff to do before exit
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileExcel.Filter = "Spreadsheets|*.xls;*.xlsx";
            openFileExcel.Title = "Select an Excel document";
            openFileExcel.Multiselect = false;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data is not null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length > 0)
            {
                // Prende solo il primo file (puoi estendere la logica per gestire più file)
                string filePath = files[0];

                // Controlla l'estensione del file
                string extension = Path.GetExtension(filePath).ToLower();

                // Lista delle estensioni accettate
                string[] acceptedExtensions = { ".xls", ".xlsx" }; // Aggiungi o rimuovi estensioni come desideri

                if (acceptedExtensions.Contains(extension))
                {
                    // Il file ha un'estensione accettata, quindi puoi passare il percorso a una variabile
                    string acceptedFilePath = filePath;

                    // Fai qualcosa con il percorso del file, ad esempio:
                    ImportFile(acceptedFilePath);
                }
                else
                {
                    MessageBox.Show("Tipo di file non supportato.");
                }
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            ExportTable();
        }

        private void ExportTable()
        {
            System.Text.StringBuilder WikiTable = new System.Text.StringBuilder();

            // Aggiungi l'intestazione della tabella
            if (chkSortable.Checked)
            {
                WikiTable.AppendLine("{| class=\"wikitable sortable\"");
            }
            else
            {
                WikiTable.AppendLine("{| class=\"wikitable\"");
            }

            // Se la prima riga è un'intestazione
            if (chkFirstRowIsHeader.Checked)
            {
                AppendRowToWikiTable(WikiTable, dgWikiTable.Rows[0], true);
            }

            // Loop sulle righe
            int rowCount = dgWikiTable.AllowUserToAddRows ? dgWikiTable.Rows.Count - 1 : dgWikiTable.Rows.Count;
            for (int rowCounter = chkFirstRowIsHeader.Checked ? 1 : 0; rowCounter < rowCount; rowCounter++)
            {
                AppendRowToWikiTable(WikiTable, dgWikiTable.Rows[rowCounter], false);
            }


            // Chiudi la tabella
            WikiTable.AppendLine("|}");

            Clipboard.SetText(WikiTable.ToString());
        }

        private void AppendRowToWikiTable(System.Text.StringBuilder WikiTable, DataGridViewRow row, bool isHeader)
        {
            WikiTable.AppendLine("|-");

            for (int colCounter = 0; colCounter < dgWikiTable.ColumnCount; colCounter++)
            {
                string cellValue = row.Cells[colCounter].Value?.ToString() ?? "";
                string cellPrefix = isHeader ? "!" : "|";

                WikiTable.AppendLine($"{cellPrefix} {cellValue}");
            }
        }

    }
}