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
            cmdForeColor = new Button();
            cmdBackColor = new Button();
            chkMantainColors = new CheckBox();
            chkSortable = new CheckBox();
            radioOutClip = new RadioButton();
            radioOutFile = new RadioButton();
            chkFirstRowIsHeader = new CheckBox();
            cmdExport = new Button();
            grpImportOptions = new GroupBox();
            chkSkipBlankLines = new CheckBox();
            stStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            progressOperation = new ToolStripProgressBar();
            label1 = new Label();
            txtCaption = new TextBox();
            colorDialogMain = new ColorDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWikiTable).BeginInit();
            grpExportOptions.SuspendLayout();
            grpImportOptions.SuspendLayout();
            stStrip.SuspendLayout();
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
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // dgWikiTable
            // 
            dgWikiTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgWikiTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgWikiTable.Location = new Point(12, 164);
            dgWikiTable.Name = "dgWikiTable";
            dgWikiTable.RowTemplate.Height = 25;
            dgWikiTable.Size = new Size(986, 312);
            dgWikiTable.TabIndex = 1;
            // 
            // grpExportOptions
            // 
            grpExportOptions.Controls.Add(cmdForeColor);
            grpExportOptions.Controls.Add(cmdBackColor);
            grpExportOptions.Controls.Add(chkMantainColors);
            grpExportOptions.Controls.Add(chkSortable);
            grpExportOptions.Controls.Add(radioOutClip);
            grpExportOptions.Controls.Add(radioOutFile);
            grpExportOptions.Controls.Add(chkFirstRowIsHeader);
            grpExportOptions.Location = new Point(331, 27);
            grpExportOptions.Name = "grpExportOptions";
            grpExportOptions.Size = new Size(352, 95);
            grpExportOptions.TabIndex = 2;
            grpExportOptions.TabStop = false;
            grpExportOptions.Text = "Export options";
            // 
            // cmdForeColor
            // 
            cmdForeColor.Enabled = false;
            cmdForeColor.Location = new Point(263, 18);
            cmdForeColor.Name = "cmdForeColor";
            cmdForeColor.Size = new Size(83, 23);
            cmdForeColor.TabIndex = 5;
            cmdForeColor.Text = "Fore Color";
            cmdForeColor.UseVisualStyleBackColor = true;
            cmdForeColor.Click += cmdForeColor_Click;
            // 
            // cmdBackColor
            // 
            cmdBackColor.Enabled = false;
            cmdBackColor.Location = new Point(175, 18);
            cmdBackColor.Name = "cmdBackColor";
            cmdBackColor.Size = new Size(83, 23);
            cmdBackColor.TabIndex = 4;
            cmdBackColor.Text = "Back Color";
            cmdBackColor.UseVisualStyleBackColor = true;
            cmdBackColor.Click += cmdBackColor_Click;
            // 
            // chkMantainColors
            // 
            chkMantainColors.AutoSize = true;
            chkMantainColors.Location = new Point(6, 72);
            chkMantainColors.Name = "chkMantainColors";
            chkMantainColors.Size = new Size(105, 19);
            chkMantainColors.TabIndex = 1;
            chkMantainColors.Text = "Mantain colors";
            chkMantainColors.UseVisualStyleBackColor = true;
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
            radioOutClip.Location = new Point(175, 70);
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
            radioOutFile.Enabled = false;
            radioOutFile.Location = new Point(175, 50);
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
            chkFirstRowIsHeader.CheckedChanged += chkFirstRowIsHeader_CheckedChanged;
            // 
            // cmdExport
            // 
            cmdExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdExport.Location = new Point(898, 27);
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
            grpImportOptions.Size = new Size(313, 95);
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
            // stStrip
            // 
            stStrip.Items.AddRange(new ToolStripItem[] { lblStatus, progressOperation });
            stStrip.Location = new Point(0, 479);
            stStrip.Name = "stStrip";
            stStrip.Size = new Size(1010, 22);
            stStrip.TabIndex = 5;
            stStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(111, 17);
            lblStatus.Text = "Operation progress:";
            // 
            // progressOperation
            // 
            progressOperation.Name = "progressOperation";
            progressOperation.Size = new Size(100, 16);
            progressOperation.Step = 1;
            progressOperation.Style = ProgressBarStyle.Continuous;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 131);
            label1.Name = "label1";
            label1.Size = new Size(272, 15);
            label1.TabIndex = 6;
            label1.Text = "Write a caption here, if you want it on top of table:";
            // 
            // txtCaption
            // 
            txtCaption.Location = new Point(290, 128);
            txtCaption.Name = "txtCaption";
            txtCaption.Size = new Size(393, 23);
            txtCaption.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 501);
            Controls.Add(txtCaption);
            Controls.Add(label1);
            Controls.Add(stStrip);
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
            stStrip.ResumeLayout(false);
            stStrip.PerformLayout();
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
        private StatusStrip stStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar progressOperation;
        private CheckBox chkMantainColors;
        private Label label1;
        private TextBox txtCaption;
        private ColorDialog colorDialogMain;
        private Button cmdBackColor;
        private Button cmdForeColor;
    }
}