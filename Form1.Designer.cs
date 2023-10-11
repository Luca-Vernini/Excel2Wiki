namespace Excel2Wiki
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileExcel = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            dgWikiTable = new DataGridView();
            grpExportOptions = new GroupBox();
            chkSortable = new CheckBox();
            radioOutClip = new RadioButton();
            radioOutFile = new RadioButton();
            chkFirstRowIsHeader = new CheckBox();
            cmdExport = new Button();
            grpImportOptions = new GroupBox();
            chkSkipBlankLines = new CheckBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWikiTable).BeginInit();
            grpExportOptions.SuspendLayout();
            grpImportOptions.SuspendLayout();
            SuspendLayout();
            // 
            // openFileExcel
            // 
            openFileExcel.FileName = "openFileDialog1";
            openFileExcel.FileOk += openFileDialog1_FileOk;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1010, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // dgWikiTable
            // 
            dgWikiTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgWikiTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgWikiTable.Location = new Point(12, 131);
            dgWikiTable.Name = "dgWikiTable";
            dgWikiTable.RowTemplate.Height = 25;
            dgWikiTable.Size = new Size(986, 358);
            dgWikiTable.TabIndex = 1;
            // 
            // grpExportOptions
            // 
            grpExportOptions.Controls.Add(chkSortable);
            grpExportOptions.Controls.Add(radioOutClip);
            grpExportOptions.Controls.Add(radioOutFile);
            grpExportOptions.Controls.Add(chkFirstRowIsHeader);
            grpExportOptions.Location = new Point(331, 27);
            grpExportOptions.Name = "grpExportOptions";
            grpExportOptions.Size = new Size(352, 86);
            grpExportOptions.TabIndex = 2;
            grpExportOptions.TabStop = false;
            grpExportOptions.Text = "Export options";
            // 
            // chkSortable
            // 
            chkSortable.AutoSize = true;
            chkSortable.Location = new Point(6, 47);
            chkSortable.Name = "chkSortable";
            chkSortable.Size = new Size(69, 19);
            chkSortable.TabIndex = 3;
            chkSortable.Text = "Sortable";
            chkSortable.UseVisualStyleBackColor = true;
            // 
            // radioOutClip
            // 
            radioOutClip.AutoSize = true;
            radioOutClip.Checked = true;
            radioOutClip.Location = new Point(176, 44);
            radioOutClip.Name = "radioOutClip";
            radioOutClip.Size = new Size(130, 19);
            radioOutClip.TabIndex = 2;
            radioOutClip.TabStop = true;
            radioOutClip.Text = "Output to clipboard";
            radioOutClip.UseVisualStyleBackColor = true;
            // 
            // radioOutFile
            // 
            radioOutFile.AutoSize = true;
            radioOutFile.Location = new Point(176, 19);
            radioOutFile.Name = "radioOutFile";
            radioOutFile.Size = new Size(96, 19);
            radioOutFile.TabIndex = 1;
            radioOutFile.Text = "Output to file";
            radioOutFile.UseVisualStyleBackColor = true;
            // 
            // chkFirstRowIsHeader
            // 
            chkFirstRowIsHeader.AutoSize = true;
            chkFirstRowIsHeader.Location = new Point(6, 22);
            chkFirstRowIsHeader.Name = "chkFirstRowIsHeader";
            chkFirstRowIsHeader.Size = new Size(124, 19);
            chkFirstRowIsHeader.TabIndex = 0;
            chkFirstRowIsHeader.Text = "First row as header";
            chkFirstRowIsHeader.UseVisualStyleBackColor = true;
            // 
            // cmdExport
            // 
            cmdExport.Location = new Point(840, 27);
            cmdExport.Name = "cmdExport";
            cmdExport.Size = new Size(100, 30);
            cmdExport.TabIndex = 3;
            cmdExport.Text = "Export";
            cmdExport.UseVisualStyleBackColor = true;
            cmdExport.Click += cmdExport_Click;
            // 
            // grpImportOptions
            // 
            grpImportOptions.Controls.Add(chkSkipBlankLines);
            grpImportOptions.Location = new Point(12, 27);
            grpImportOptions.Name = "grpImportOptions";
            grpImportOptions.Size = new Size(279, 86);
            grpImportOptions.TabIndex = 4;
            grpImportOptions.TabStop = false;
            grpImportOptions.Text = "Import Options";
            // 
            // chkSkipBlankLines
            // 
            chkSkipBlankLines.AutoSize = true;
            chkSkipBlankLines.Checked = true;
            chkSkipBlankLines.CheckState = CheckState.Checked;
            chkSkipBlankLines.Location = new Point(6, 22);
            chkSkipBlankLines.Name = "chkSkipBlankLines";
            chkSkipBlankLines.Size = new Size(107, 19);
            chkSkipBlankLines.TabIndex = 0;
            chkSkipBlankLines.Text = "Skip blank lines";
            chkSkipBlankLines.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 501);
            Controls.Add(grpImportOptions);
            Controls.Add(cmdExport);
            Controls.Add(grpExportOptions);
            Controls.Add(dgWikiTable);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Excel 2 Wiki";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgWikiTable).EndInit();
            grpExportOptions.ResumeLayout(false);
            grpExportOptions.PerformLayout();
            grpImportOptions.ResumeLayout(false);
            grpImportOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileExcel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private DataGridView dgWikiTable;
        private GroupBox grpExportOptions;
        private CheckBox chkFirstRowIsHeader;
        private RadioButton radioOutClip;
        private RadioButton radioOutFile;
        private Button cmdExport;
        private CheckBox chkSortable;
        private GroupBox grpImportOptions;
        private CheckBox chkSkipBlankLines;
    }
}