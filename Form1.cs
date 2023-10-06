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

        private void ImportFile(string fullpath)
        {
            MessageBox.Show(fullpath);
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
                    MessageBox.Show($"Hai rilasciato il file: {acceptedFilePath}");
                }
                else
                {
                    MessageBox.Show("Tipo di file non supportato.");
                }
            }
        }
    }
}