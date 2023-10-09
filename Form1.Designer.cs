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
            grpOptions = new GroupBox();
            radioOutClip = new RadioButton();
            radioOutFile = new RadioButton();
            chkFirstRowIsHeader = new CheckBox();
            cmdExport = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWikiTable).BeginInit();
            grpOptions.SuspendLayout();
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
            // grpOptions
            // 
            grpOptions.Controls.Add(radioOutClip);
            grpOptions.Controls.Add(radioOutFile);
            grpOptions.Controls.Add(chkFirstRowIsHeader);
            grpOptions.Location = new Point(16, 28);
            grpOptions.Name = "grpOptions";
            grpOptions.Size = new Size(352, 86);
            grpOptions.TabIndex = 2;
            grpOptions.TabStop = false;
            grpOptions.Text = "Options";
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
            cmdExport.Location = new Point(374, 36);
            cmdExport.Name = "cmdExport";
            cmdExport.Size = new Size(100, 30);
            cmdExport.TabIndex = 3;
            cmdExport.Text = "Export";
            cmdExport.UseVisualStyleBackColor = true;
            cmdExport.Click += cmdExport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 501);
            Controls.Add(cmdExport);
            Controls.Add(grpOptions);
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
            grpOptions.ResumeLayout(false);
            grpOptions.PerformLayout();
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
        private GroupBox grpOptions;
        private CheckBox chkFirstRowIsHeader;
        private RadioButton radioOutClip;
        private RadioButton radioOutFile;
        private Button cmdExport;
    }
}