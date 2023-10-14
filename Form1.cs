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

            //Reset status bar components
            progressOperation.Value = 0;
            lblStatus.Text = "Import in progress";


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

                //Opening file is 5 percent of the work
                progressOperation.Value = 5;
                stStrip.Refresh();

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

            // Another 5% for the header
            progressOperation.Value = 10;
            stStrip.Refresh();

            double mappedValue;
            // add the rows
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);

                // If the checkbox is not checked or the row is not empty, add the row to the DataGridView
                if (!chkSkipBlankLines.Checked || !IsRowEmpty(row))
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dgWikiTable);

                    for (int j = 0; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            // add more logic here
                            newRow.Cells[j].Value = row.GetCell(j).ToString();
                        }
                    }

                    dgWikiTable.Rows.Add(newRow);
                }

                // Update the progress bar based on the total number of rows processed
                mappedValue = MapValue(i, 0, sheet.LastRowNum, 10, progressOperation.Maximum);
                progressOperation.Value = (int)Math.Round(mappedValue);
                stStrip.Refresh();
            }

        }
        public double MapValue(double input, double inputMin, double inputMax, double outputMin, double outputMax)
        {
            return outputMin + ((input - inputMin) / (inputMax - inputMin) * (outputMax - outputMin));
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
            progressOperation.Value = 0;
            double mappedValue;

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

            progressOperation.Value = 1;

            // Loop sulle righe
            int rowCount = dgWikiTable.AllowUserToAddRows ? dgWikiTable.Rows.Count - 1 : dgWikiTable.Rows.Count;
            for (int rowCounter = chkFirstRowIsHeader.Checked ? 1 : 0; rowCounter < rowCount; rowCounter++)
            {
                AppendRowToWikiTable(WikiTable, dgWikiTable.Rows[rowCounter], false);
                mappedValue = MapValue(rowCount, 0, dgWikiTable.RowCount, 1, progressOperation.Maximum);
                progressOperation.Value = (int)Math.Round(mappedValue);
            }

            // Chiudi la tabella
            WikiTable.AppendLine("|}");
            progressOperation.Value = 100;

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