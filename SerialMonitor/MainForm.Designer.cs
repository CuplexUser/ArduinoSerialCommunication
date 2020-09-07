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
            this.spContainer = new System.Windows.Forms.SplitContainer();
            this.txtSendText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlButtonSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlDropDownSettings = new System.Windows.Forms.Panel();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drpRowOptions = new System.Windows.Forms.ComboBox();
            this.pnlChkBoxSettings = new System.Windows.Forms.Panel();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.chkShowTimeStamps = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtBoxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.Panel2.SuspendLayout();
            this.spContainer.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlButtonSettings.SuspendLayout();
            this.pnlDropDownSettings.SuspendLayout();
            this.pnlChkBoxSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRecievedData
            // 
            this.txtRecievedData.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.txtRecievedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecievedData.ContextMenuStrip = this.txtBoxMenu;
            this.txtRecievedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecievedData.Font = new System.Drawing.Font("Verdana Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecievedData.Location = new System.Drawing.Point(2, 2);
            this.txtRecievedData.Name = "txtRecievedData";
            this.txtRecievedData.ReadOnly = true;
            this.txtRecievedData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRecievedData.Size = new System.Drawing.Size(761, 272);
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
            this.txtBoxMenu.Size = new System.Drawing.Size(157, 120);
            // 
            // popupMenuCopy
            // 
            this.popupMenuCopy.Name = "popupMenuCopy";
            this.popupMenuCopy.Size = new System.Drawing.Size(156, 22);
            this.popupMenuCopy.Text = "&Copy Selection";
            // 
            // popupMenuSave
            // 
            this.popupMenuSave.Name = "popupMenuSave";
            this.popupMenuSave.Size = new System.Drawing.Size(156, 22);
            this.popupMenuSave.Text = "&Save Textfile";
            // 
            // popupMenuOpenFile
            // 
            this.popupMenuOpenFile.Name = "popupMenuOpenFile";
            this.popupMenuOpenFile.Size = new System.Drawing.Size(156, 22);
            this.popupMenuOpenFile.Text = "Append Textfile";
            // 
            // popupMenuSeparator
            // 
            this.popupMenuSeparator.Name = "popupMenuSeparator";
            this.popupMenuSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // popupMenuReconnect
            // 
            this.popupMenuReconnect.Name = "popupMenuReconnect";
            this.popupMenuReconnect.Size = new System.Drawing.Size(156, 22);
            this.popupMenuReconnect.Text = "Reconnect";
            // 
            // popupMenuDisconnect
            // 
            this.popupMenuDisconnect.Name = "popupMenuDisconnect";
            this.popupMenuDisconnect.Size = new System.Drawing.Size(156, 22);
            this.popupMenuDisconnect.Text = "Disconnect";
            // 
            // spContainer
            // 
            this.spContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spContainer.IsSplitterFixed = true;
            this.spContainer.Location = new System.Drawing.Point(6, 2);
            this.spContainer.MinimumSize = new System.Drawing.Size(758, 300);
            this.spContainer.Name = "spContainer";
            this.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.txtSendText);
            this.spContainer.Panel1.Controls.Add(this.btnSend);
            this.spContainer.Panel1.Padding = new System.Windows.Forms.Padding(2);
            this.spContainer.Panel1MinSize = 35;
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.Controls.Add(this.txtRecievedData);
            this.spContainer.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.spContainer.Panel2MinSize = 100;
            this.spContainer.Size = new System.Drawing.Size(765, 316);
            this.spContainer.SplitterDistance = 35;
            this.spContainer.SplitterWidth = 5;
            this.spContainer.TabIndex = 3;
            this.spContainer.Resize += new System.EventHandler(this.spContainer_Resize);
            // 
            // txtSendText
            // 
            this.txtSendText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendText.Location = new System.Drawing.Point(6, 9);
            this.txtSendText.MaxLength = 512;
            this.txtSendText.Name = "txtSendText";
            this.txtSendText.Size = new System.Drawing.Size(664, 23);
            this.txtSendText.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(675, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(82, 29);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.Controls.Add(this.pnlButtonSettings);
            this.pnlOptions.Controls.Add(this.pnlDropDownSettings);
            this.pnlOptions.Controls.Add(this.pnlChkBoxSettings);
            this.pnlOptions.Location = new System.Drawing.Point(3, 324);
            this.pnlOptions.MinimumSize = new System.Drawing.Size(758, 35);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOptions.Size = new System.Drawing.Size(768, 35);
            this.pnlOptions.TabIndex = 5;
            // 
            // pnlButtonSettings
            // 
            this.pnlButtonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtonSettings.Controls.Add(this.btnExitApp);
            this.pnlButtonSettings.Controls.Add(this.btnSettings);
            this.pnlButtonSettings.Controls.Add(this.btnClear);
            this.pnlButtonSettings.Location = new System.Drawing.Point(511, 3);
            this.pnlButtonSettings.Name = "pnlButtonSettings";
            this.pnlButtonSettings.Size = new System.Drawing.Size(257, 33);
            this.pnlButtonSettings.TabIndex = 11;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(83, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(80, 26);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(169, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 26);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlDropDownSettings
            // 
            this.pnlDropDownSettings.Controls.Add(this.label1);
            this.pnlDropDownSettings.Controls.Add(this.drpRowOptions);
            this.pnlDropDownSettings.Location = new System.Drawing.Point(241, 3);
            this.pnlDropDownSettings.Name = "pnlDropDownSettings";
            this.pnlDropDownSettings.Size = new System.Drawing.Size(275, 35);
            this.pnlDropDownSettings.TabIndex = 10;
            // 
            // btnExitApp
            // 
            this.btnExitApp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitApp.Location = new System.Drawing.Point(12, 4);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(65, 26);
            this.btnExitApp.TabIndex = 6;
            this.btnExitApp.Text = "Exit";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "New Line char";
            // 
            // drpRowOptions
            // 
            this.drpRowOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpRowOptions.FormattingEnabled = true;
            this.drpRowOptions.Location = new System.Drawing.Point(103, 7);
            this.drpRowOptions.Name = "drpRowOptions";
            this.drpRowOptions.Size = new System.Drawing.Size(135, 23);
            this.drpRowOptions.TabIndex = 4;
            // 
            // pnlChkBoxSettings
            // 
            this.pnlChkBoxSettings.Controls.Add(this.chkAutoScroll);
            this.pnlChkBoxSettings.Controls.Add(this.chkShowTimeStamps);
            this.pnlChkBoxSettings.Location = new System.Drawing.Point(7, 3);
            this.pnlChkBoxSettings.Name = "pnlChkBoxSettings";
            this.pnlChkBoxSettings.Size = new System.Drawing.Size(231, 35);
            this.pnlChkBoxSettings.TabIndex = 9;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Location = new System.Drawing.Point(7, 8);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(80, 19);
            this.chkAutoScroll.TabIndex = 0;
            this.chkAutoScroll.Text = "Autoscroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.CheckStateChanged += new System.EventHandler(this.chkAutoScroll_CheckStateChanged);
            // 
            // chkShowTimeStamps
            // 
            this.chkShowTimeStamps.AutoSize = true;
            this.chkShowTimeStamps.Location = new System.Drawing.Point(98, 8);
            this.chkShowTimeStamps.Name = "chkShowTimeStamps";
            this.chkShowTimeStamps.Size = new System.Drawing.Size(122, 19);
            this.chkShowTimeStamps.TabIndex = 1;
            this.chkShowTimeStamps.Text = "Show Timestamps";
            this.chkShowTimeStamps.UseVisualStyleBackColor = true;
            this.chkShowTimeStamps.CheckStateChanged += new System.EventHandler(this.chkShowTimeStamps_CheckStateChanged);
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
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 366);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 17);
            this.lblStatus.Text = "Disconnected";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExitApp;
            this.ClientSize = new System.Drawing.Size(775, 388);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.spContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(791, 427);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Monitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.txtBoxMenu.ResumeLayout(false);
            this.spContainer.Panel1.ResumeLayout(false);
            this.spContainer.Panel1.PerformLayout();
            this.spContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
            this.spContainer.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlButtonSettings.ResumeLayout(false);
            this.pnlDropDownSettings.ResumeLayout(false);
            this.pnlDropDownSettings.PerformLayout();
            this.pnlChkBoxSettings.ResumeLayout(false);
            this.pnlChkBoxSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtRecievedData;
        private System.Windows.Forms.SplitContainer spContainer;
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
        private System.Windows.Forms.Panel pnlButtonSettings;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlDropDownSettings;
        private System.Windows.Forms.ComboBox drpRowOptions;
        private System.Windows.Forms.Panel pnlChkBoxSettings;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.CheckBox chkShowTimeStamps;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitApp;
    }
}

