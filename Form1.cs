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
        private ExcelProcessor excelProcessor;
        private WikiTableGenerator wikiTableGenerator;

        public Form1()
        {
            InitializeComponent();

            excelProcessor = new ExcelProcessor();
            wikiTableGenerator = new WikiTableGenerator();
            //enable drag and drop
            this.AllowDrop = true;

            //work in progress, for now let buttons invisible
            cmdForeColor.Visible = false;
            cmdBackColor.Visible = false;
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

        private void ImportFile(string fullPath)
        {
            try
            {
                var dataTable = excelProcessor.ImportFile(fullPath, chkSkipBlankLines.Checked);

                // Mostra i dati nel DataGridView
                dgWikiTable.DataSource = dataTable;

                lblStatus.Text = "Import complete";
                stStrip.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'importazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblStatus.Text = "Export in progress:";
            progressOperation.Value = 0;

            // Crea un'istanza di WikiTableGenerator
            var generator = new WikiTableGenerator();

            // Genera la tabella Wiki
            string wikiTable = generator.GenerateWikiTable(
                dgWikiTable,
                chkSortable.Checked,
                chkFirstRowIsHeader.Checked,
                txtCaption.Text
            );

            // Decidi dove esportare in base al RadioButton selezionato
            if (radioOutClip.Checked)
            {
                Clipboard.SetText(wikiTable);
                MessageBox.Show("La tabella è stata copiata negli appunti!", "Esportazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioOutFile.Checked)
            {
                SaveToFile(wikiTable);
            }

            lblStatus.Text = "Export complete";
            progressOperation.Value = 100;
            stStrip.Refresh();
        }

        private void SaveToFile(string wikiTable)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Wiki Table";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, wikiTable);
                        MessageBox.Show("File salvato con successo!", "Esportazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore durante il salvataggio del file: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /*private void AppendRowToWikiTable(System.Text.StringBuilder WikiTable, DataGridViewRow row, bool isHeader)
        {
            WikiTable.AppendLine("|-");

            for (int colCounter = 0; colCounter < dgWikiTable.ColumnCount; colCounter++)
            {
                string cellValue = row.Cells[colCounter].Value?.ToString() ?? "";
                string cellPrefix = isHeader ? "!" : "|";

                WikiTable.AppendLine($"{cellPrefix} {cellValue}");
            }
        }*/

        private void cmdBackColor_Click(object sender, EventArgs e)
        {
            Color? selectedColor = PickAColor();
            if (selectedColor.HasValue)
            {
                if (dgWikiTable.Rows.Count > 0)
                {
                    foreach (DataGridViewCell cell in dgWikiTable.Rows[0].Cells)
                    {
                        cell.Style.BackColor = selectedColor.Value;
                    }
                }
            }
        }

        private Color? PickAColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                return (colorDialog.Color);
            }

            return null;
        }

        private void chkFirstRowIsHeader_CheckedChanged(object sender, EventArgs e)
        {
            cmdBackColor.Enabled = chkFirstRowIsHeader.Checked;
            cmdForeColor.Enabled = chkFirstRowIsHeader.Checked;
        }

        private void cmdForeColor_Click(object sender, EventArgs e)
        {
            Color? selectedColor = PickAColor();
            if (selectedColor.HasValue)
            {
                if (dgWikiTable.Rows.Count > 0)
                {
                    foreach (DataGridViewCell cell in dgWikiTable.Rows[0].Cells)
                    {
                        cell.Style.ForeColor = selectedColor.Value;
                    }
                }
            }
        }
    }
}