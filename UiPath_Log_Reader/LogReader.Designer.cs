namespace LogReader
{
    partial class LogReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogReader));
            this.FileList = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ChooseFile = new System.Windows.Forms.Label();
            this.LogLevel = new System.Windows.Forms.Label();
            this.Refresh2 = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.RowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ChooseProcess = new System.Windows.Forms.Label();
            this.ProcessTimeStamp = new System.Windows.Forms.ComboBox();
            this.PListDropDown = new System.Windows.Forms.ComboBox();
            this.Browse = new System.Windows.Forms.Button();
            this.MessageFilterValue = new System.Windows.Forms.TextBox();
            this.MessgeFilter = new System.Windows.Forms.Button();
            this.GotoVal = new System.Windows.Forms.TextBox();
            this.Goto = new System.Windows.Forms.Button();
            this.CopyHeader = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileList
            // 
            this.FileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(22, 17);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(223, 21);
            this.FileList.TabIndex = 0;
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // Level
            // 
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(928, 305);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // CheckedListBox1
            // 
            this.CheckedListBox1.CheckOnClick = true;
            this.CheckedListBox1.FormattingEnabled = true;
            this.CheckedListBox1.Items.AddRange(new object[] {
            "Trace",
            "Information",
            "Warning",
            "Error",
            "Fatal"});
            this.CheckedListBox1.Location = new System.Drawing.Point(484, 9);
            this.CheckedListBox1.Name = "CheckedListBox1";
            this.CheckedListBox1.Size = new System.Drawing.Size(114, 49);
            this.CheckedListBox1.TabIndex = 4;
            this.CheckedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // ChooseFile
            // 
            this.ChooseFile.AutoSize = true;
            this.ChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseFile.Location = new System.Drawing.Point(19, 0);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(82, 17);
            this.ChooseFile.TabIndex = 5;
            this.ChooseFile.Text = "ChooseFile:";
            // 
            // LogLevel
            // 
            this.LogLevel.AutoSize = true;
            this.LogLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLevel.Location = new System.Drawing.Point(273, 9);
            this.LogLevel.Name = "LogLevel";
            this.LogLevel.Size = new System.Drawing.Size(74, 17);
            this.LogLevel.TabIndex = 6;
            this.LogLevel.Text = "Log Level:";
            // 
            // Refresh2
            // 
            this.Refresh2.BackColor = System.Drawing.SystemColors.Window;
            this.Refresh2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Refresh2.Location = new System.Drawing.Point(330, 15);
            this.Refresh2.Name = "Refresh2";
            this.Refresh2.Size = new System.Drawing.Size(75, 24);
            this.Refresh2.TabIndex = 7;
            this.Refresh2.Text = "Reload";
            this.Refresh2.UseVisualStyleBackColor = true;
            this.Refresh2.Click += new System.EventHandler(this.Refresh2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RowCount
            // 
            this.RowCount.Name = "RowCount";
            this.RowCount.Size = new System.Drawing.Size(0, 17);
            // 
            // ChooseProcess
            // 
            this.ChooseProcess.AutoSize = true;
            this.ChooseProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProcess.Location = new System.Drawing.Point(20, 47);
            this.ChooseProcess.Name = "ChooseProcess";
            this.ChooseProcess.Size = new System.Drawing.Size(115, 17);
            this.ChooseProcess.TabIndex = 10;
            this.ChooseProcess.Text = "Choose Process:";
            // 
            // ProcessTimeStamp
            // 
            this.ProcessTimeStamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProcessTimeStamp.FormattingEnabled = true;
            this.ProcessTimeStamp.Location = new System.Drawing.Point(437, 64);
            this.ProcessTimeStamp.Name = "ProcessTimeStamp";
            this.ProcessTimeStamp.Size = new System.Drawing.Size(161, 21);
            this.ProcessTimeStamp.TabIndex = 12;
            this.ProcessTimeStamp.SelectedIndexChanged += new System.EventHandler(this.ProcessTimeStamp_SelectedIndexChanged);
            // 
            // PListDropDown
            // 
            this.PListDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PListDropDown.FormattingEnabled = true;
            this.PListDropDown.Location = new System.Drawing.Point(22, 64);
            this.PListDropDown.Name = "PListDropDown";
            this.PListDropDown.Size = new System.Drawing.Size(409, 21);
            this.PListDropDown.TabIndex = 13;
            this.PListDropDown.SelectedIndexChanged += new System.EventHandler(this.PListDropDown_SelectedIndexChanged);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(251, 15);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 24);
            this.Browse.TabIndex = 14;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // MessageFilterValue
            // 
            this.MessageFilterValue.AcceptsReturn = true;
            this.MessageFilterValue.Location = new System.Drawing.Point(614, 66);
            this.MessageFilterValue.Name = "MessageFilterValue";
            this.MessageFilterValue.Size = new System.Drawing.Size(138, 20);
            this.MessageFilterValue.TabIndex = 16;
            this.MessageFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageValueFilter_KeyPress);
            // 
            // MessgeFilter
            // 
            this.MessgeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessgeFilter.Location = new System.Drawing.Point(614, 39);
            this.MessgeFilter.Name = "MessgeFilter";
            this.MessgeFilter.Size = new System.Drawing.Size(138, 23);
            this.MessgeFilter.TabIndex = 18;
            this.MessgeFilter.Text = "Where Message/s like";
            this.MessgeFilter.UseVisualStyleBackColor = true;
            this.MessgeFilter.Click += new System.EventHandler(this.SearchButton);
            // 
            // GotoVal
            // 
            this.GotoVal.Location = new System.Drawing.Point(757, 66);
            this.GotoVal.Name = "GotoVal";
            this.GotoVal.Size = new System.Drawing.Size(78, 20);
            this.GotoVal.TabIndex = 19;
            this.GotoVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoVal_KeyPress);
            // 
            // Goto
            // 
            this.Goto.Location = new System.Drawing.Point(756, 39);
            this.Goto.Name = "Goto";
            this.Goto.Size = new System.Drawing.Size(78, 23);
            this.Goto.TabIndex = 20;
            this.Goto.Text = "Goto Row#";
            this.Goto.UseVisualStyleBackColor = true;
            this.Goto.Click += new System.EventHandler(this.Goto_Click);
            // 
            // CopyHeader
            // 
            this.CopyHeader.AutoSize = true;
            this.CopyHeader.Location = new System.Drawing.Point(805, 9);
            this.CopyHeader.Name = "CopyHeader";
            this.CopyHeader.Size = new System.Drawing.Size(145, 17);
            this.CopyHeader.TabIndex = 21;
            this.CopyHeader.Text = "Copy with column header";
            this.CopyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CopyHeader.UseVisualStyleBackColor = true;
            this.CopyHeader.CheckedChanged += new System.EventHandler(this.CopyHeader_CheckedChanged);
            // 
            // LogReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(962, 425);
            this.Controls.Add(this.CopyHeader);
            this.Controls.Add(this.Goto);
            this.Controls.Add(this.GotoVal);
            this.Controls.Add(this.MessgeFilter);
            this.Controls.Add(this.MessageFilterValue);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.PListDropDown);
            this.Controls.Add(this.ProcessTimeStamp);
            this.Controls.Add(this.ChooseProcess);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Refresh2);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.CheckedListBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FileList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogReader";
            this.Text = "Log File Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FileList;
        //private System.Windows.Forms.DataGridView dtGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox CheckedListBox1;
        private System.Windows.Forms.Label ChooseFile;
        private System.Windows.Forms.Label LogLevel;
        private System.Windows.Forms.Button Refresh2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel RowCount;
        private System.Windows.Forms.Label ChooseProcess;
        private System.Windows.Forms.ComboBox ProcessTimeStamp;
        private System.Windows.Forms.ComboBox PListDropDown;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox MessageFilterValue;
        private System.Windows.Forms.Button MessgeFilter;
        private System.Windows.Forms.TextBox GotoVal;
        private System.Windows.Forms.Button Goto;
        private System.Windows.Forms.CheckBox CopyHeader;
    }
}

