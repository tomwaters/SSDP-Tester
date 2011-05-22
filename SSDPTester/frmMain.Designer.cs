namespace SSDPTester
{
    partial class frmMain
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
            this.lvMsgs = new System.Windows.Forms.ListView();
            this.chTime = new System.Windows.Forms.ColumnHeader();
            this.chSrc = new System.Windows.Forms.ColumnHeader();
            this.chDest = new System.Windows.Forms.ColumnHeader();
            this.chMsg = new System.Windows.Forms.ColumnHeader();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.svCSV = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lvMsgs
            // 
            this.lvMsgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMsgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTime,
            this.chSrc,
            this.chDest,
            this.chMsg});
            this.lvMsgs.FullRowSelect = true;
            this.lvMsgs.Location = new System.Drawing.Point(12, 38);
            this.lvMsgs.MultiSelect = false;
            this.lvMsgs.Name = "lvMsgs";
            this.lvMsgs.Size = new System.Drawing.Size(601, 272);
            this.lvMsgs.TabIndex = 1;
            this.lvMsgs.UseCompatibleStateImageBehavior = false;
            this.lvMsgs.View = System.Windows.Forms.View.Details;
            this.lvMsgs.DoubleClick += new System.EventHandler(this.lvMsgs_DoubleClick);
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 120;
            // 
            // chSrc
            // 
            this.chSrc.Text = "Source";
            this.chSrc.Width = 120;
            // 
            // chDest
            // 
            this.chDest.Text = "Destination";
            this.chDest.Width = 120;
            // 
            // chMsg
            // 
            this.chMsg.Text = "Message";
            this.chMsg.Width = 279;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(87, 9);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 9);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(69, 23);
            this.btnStartStop.TabIndex = 4;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(162, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(237, 9);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(69, 23);
            this.btnCSV.TabIndex = 6;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // svCSV
            // 
            this.svCSV.DefaultExt = "csv";
            this.svCSV.FileName = "SSDPTester.csv";
            this.svCSV.Filter = "CSV files|*.csv|All files|*.*";
            this.svCSV.Title = "Export to CSV";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 322);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lvMsgs);
            this.Name = "frmMain";
            this.Text = "SSDP Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMsgs;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ColumnHeader chSrc;
        private System.Windows.Forms.ColumnHeader chDest;
        private System.Windows.Forms.ColumnHeader chMsg;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.SaveFileDialog svCSV;

    }
}

