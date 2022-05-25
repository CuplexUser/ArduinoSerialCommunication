namespace SerialMonitor
{
    partial class MainForm
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
            if (disposing)
            {
                _serialComService?.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtRecievedData = new System.Windows.Forms.RichTextBox();
            this.txtBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popupMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.popupMenuReconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSendText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.chkShowTimeStamps = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnQuickConnect = new System.Windows.Forms.Button();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBoxSend = new System.Windows.Forms.GroupBox();
            this.grpBoxRecieveData = new System.Windows.Forms.GroupBox();
            this.txtBoxMenu.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpBoxSend.SuspendLayout();
            this.grpBoxRecieveData.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRecievedData
            // 
            this.txtRecievedData.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.txtRecievedData.AutoWordSelection = true;
            this.txtRecievedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecievedData.ContextMenuStrip = this.txtBoxMenu;
            this.txtRecievedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecievedData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecievedData.Location = new System.Drawing.Point(6, 19);
            this.txtRecievedData.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecievedData.Name = "txtRecievedData";
            this.txtRecievedData.ReadOnly = true;
            this.txtRecievedData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRecievedData.Size = new System.Drawing.Size(915, 413);
            this.txtRecievedData.TabIndex = 2;
            this.txtRecievedData.Text = "";
            // 
            // txtBoxMenu
            // 
            this.txtBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupMenuCopy,
            this.popupMenuSave,
            this.popupMenuOpenFile,
            this.popupMenuSeparator,
            this.popupMenuReconnect,
            this.popupMenuDisconnect});
            this.txtBoxMenu.Name = "txtBoxMenu";
            this.txtBoxMenu.Size = new System.Drawing.Size(155, 120);
            // 
            // popupMenuCopy
            // 
            this.popupMenuCopy.Name = "popupMenuCopy";
            this.popupMenuCopy.Size = new System.Drawing.Size(154, 22);
            this.popupMenuCopy.Text = "&CopyText";
            this.popupMenuCopy.Click += new System.EventHandler(this.popupMenuCopy_Click);
            // 
            // popupMenuSave
            // 
            this.popupMenuSave.Name = "popupMenuSave";
            this.popupMenuSave.Size = new System.Drawing.Size(154, 22);
            this.popupMenuSave.Text = "&Save As Textfile";
            this.popupMenuSave.Click += new System.EventHandler(this.popupMenuSave_Click);
            // 
            // popupMenuOpenFile
            // 
            this.popupMenuOpenFile.Name = "popupMenuOpenFile";
            this.popupMenuOpenFile.Size = new System.Drawing.Size(154, 22);
            this.popupMenuOpenFile.Text = "Load Textfile";
            this.popupMenuOpenFile.Click += new System.EventHandler(this.popupMenuOpenFile_Click);
            // 
            // popupMenuSeparator
            // 
            this.popupMenuSeparator.Name = "popupMenuSeparator";
            this.popupMenuSeparator.Size = new System.Drawing.Size(151, 6);
            // 
            // popupMenuReconnect
            // 
            this.popupMenuReconnect.Name = "popupMenuReconnect";
            this.popupMenuReconnect.Size = new System.Drawing.Size(154, 22);
            this.popupMenuReconnect.Text = "Connect";
            this.popupMenuReconnect.Click += new System.EventHandler(this.popupMenuReconnect_Click);
            // 
            // popupMenuDisconnect
            // 
            this.popupMenuDisconnect.Name = "popupMenuDisconnect";
            this.popupMenuDisconnect.Size = new System.Drawing.Size(154, 22);
            this.popupMenuDisconnect.Text = "Disconnect";
            this.popupMenuDisconnect.Click += new System.EventHandler(this.popupMenuDisconnect_Click);
            // 
            // txtSendText
            // 
            this.txtSendText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendText.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendText.Location = new System.Drawing.Point(6, 21);
            this.txtSendText.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtSendText.MaxLength = 512;
            this.txtSendText.Name = "txtSendText";
            this.txtSendText.Size = new System.Drawing.Size(829, 25);
            this.txtSendText.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(841, 21);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 26);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.flowLayoutPanel1);
            this.pnlOptions.Controls.Add(this.flowLayoutPanel2);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.Location = new System.Drawing.Point(0, 491);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOptions.MinimumSize = new System.Drawing.Size(580, 25);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(2);
            this.pnlOptions.Size = new System.Drawing.Size(927, 30);
            this.pnlOptions.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.chkAutoScroll);
            this.flowLayoutPanel1.Controls.Add(this.chkShowTimeStamps);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(216, 23);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Location = new System.Drawing.Point(2, 2);
            this.chkAutoScroll.Margin = new System.Windows.Forms.Padding(0);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(80, 19);
            this.chkAutoScroll.TabIndex = 2;
            this.chkAutoScroll.Text = "Autoscroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckStateChanged);
            // 
            // chkShowTimeStamps
            // 
            this.chkShowTimeStamps.AutoSize = true;
            this.chkShowTimeStamps.Location = new System.Drawing.Point(82, 2);
            this.chkShowTimeStamps.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowTimeStamps.Name = "chkShowTimeStamps";
            this.chkShowTimeStamps.Size = new System.Drawing.Size(122, 19);
            this.chkShowTimeStamps.TabIndex = 3;
            this.chkShowTimeStamps.Text = "Show Timestamps";
            this.chkShowTimeStamps.UseVisualStyleBackColor = true;
            this.chkShowTimeStamps.CheckedChanged += new System.EventHandler(this.chkShowTimeStamps_CheckStateChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btnClear);
            this.flowLayoutPanel2.Controls.Add(this.btnSettings);
            this.flowLayoutPanel2.Controls.Add(this.btnQuickConnect);
            this.flowLayoutPanel2.Controls.Add(this.btnExitApp);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(586, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(338, 27);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(262, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 24);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(184, 2);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 24);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnQuickConnect
            // 
            this.btnQuickConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickConnect.Location = new System.Drawing.Point(81, 2);
            this.btnQuickConnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQuickConnect.Name = "btnQuickConnect";
            this.btnQuickConnect.Size = new System.Drawing.Size(95, 24);
            this.btnQuickConnect.TabIndex = 10;
            this.btnQuickConnect.Text = "Quick Connect";
            this.btnQuickConnect.UseVisualStyleBackColor = true;
            this.btnQuickConnect.Click += new System.EventHandler(this.btnQuickConnect_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitApp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitApp.Location = new System.Drawing.Point(6, 2);
            this.btnExitApp.Margin = new System.Windows.Forms.Padding(2, 0, 6, 0);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(65, 24);
            this.btnExitApp.TabIndex = 9;
            this.btnExitApp.Text = "Exit";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatus2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 17);
            this.lblStatus.Text = "Disconnected";
            // 
            // lblStatus2
            // 
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(18, 17);
            this.lblStatus2.Text = " - ";
            // 
            // grpBoxSend
            // 
            this.grpBoxSend.Controls.Add(this.txtSendText);
            this.grpBoxSend.Controls.Add(this.btnSend);
            this.grpBoxSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoxSend.Location = new System.Drawing.Point(0, 0);
            this.grpBoxSend.Name = "grpBoxSend";
            this.grpBoxSend.Size = new System.Drawing.Size(927, 56);
            this.grpBoxSend.TabIndex = 7;
            this.grpBoxSend.TabStop = false;
            this.grpBoxSend.Text = "Send text";
            // 
            // grpBoxRecieveData
            // 
            this.grpBoxRecieveData.Controls.Add(this.txtRecievedData);
            this.grpBoxRecieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxRecieveData.Location = new System.Drawing.Point(0, 56);
            this.grpBoxRecieveData.Name = "grpBoxRecieveData";
            this.grpBoxRecieveData.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.grpBoxRecieveData.Size = new System.Drawing.Size(927, 435);
            this.grpBoxRecieveData.TabIndex = 8;
            this.grpBoxRecieveData.TabStop = false;
            this.grpBoxRecieveData.Text = "Recieved Data";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(927, 543);
            this.Controls.Add(this.grpBoxRecieveData);
            this.Controls.Add(this.grpBoxSend);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.txtBoxMenu.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpBoxSend.ResumeLayout(false);
            this.grpBoxSend.PerformLayout();
            this.grpBoxRecieveData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtRecievedData;
        private System.Windows.Forms.TextBox txtSendText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip txtBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem popupMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem popupMenuSave;
        private System.Windows.Forms.ToolStripMenuItem popupMenuOpenFile;
        private System.Windows.Forms.ToolStripSeparator popupMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem popupMenuReconnect;
        private System.Windows.Forms.ToolStripMenuItem popupMenuDisconnect;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.CheckBox chkShowTimeStamps;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnExitApp;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuickConnect;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus2;
        private System.Windows.Forms.GroupBox grpBoxSend;
        private System.Windows.Forms.GroupBox grpBoxRecieveData;
    }
}

