using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SerialMonitor.EventStatus;
using SerialMonitor.Helpers;
using SerialMonitor.Properties;
using SerialMonitor.Service;
using StorageModule.Models;
using StorageModule.Models.Enums;
using StorageModule.Provider;

namespace SerialMonitor
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// The serial COM service
        /// </summary>
        private readonly SerialComService _serialComService = SerialComService.Instance;

        private readonly AppSettingsModel _applicationState;
        //private readonly Settings _appSettings;


        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            var settingsProvider = new AppSettingsProvider();
            _applicationState = settingsProvider.LoadSettings<AppSettingsModel>();

            if (_applicationState == null)
            {
                _applicationState = new AppSettingsModel
                {
                    AutoScrollText = true,
                    BaudRate = 115200,
                    EnableTimestamps = true,
                    Status = ConnectionStatus.None
                };
            }
        }

        /// <summary>
        /// Handles the Resize event of the spContainer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void spContainer_Resize(object sender, EventArgs e)
        {
            spContainer.PerformAutoScale();
        }

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _serialComService.SerialDataReceived += OnSerialComService_SerialDataReceived;
            _serialComService.SerialConnectionStateChanged += _serialComService_SerialConnectionStateChanged;
            Text = ApplicationDataHelper.GetMainFormTitle();

            _applicationState.Status = ConnectionStatus.None;
            UpdateGuiFromAppState();
        }



        /// <summary>
        /// Handles the SerialConnectionStateChanged event of the _serialComService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="EventStatus.SerialConStatusChangedEventArgs"/> instance containing the event data.</param>
        private void _serialComService_SerialConnectionStateChanged(object sender, SerialConStatusChangedEventArgs args)
        {
            if (args.ActiveStatus == ConnectionStatus.Connected)
            {
                _applicationState.Status = ConnectionStatus.Connected;

            }
            else if (args.ActiveStatus == ConnectionStatus.Disconnected)
            {
                _applicationState.Status = ConnectionStatus.Disconnected;

            }
            else
            {
                _applicationState.Status = ConnectionStatus.Error;
                AppendToReceivedData(args.Message + "\r\n");
            }

            UpdateGuiFromAppState();
        }


        /// <summary>
        /// Called when [serial COM service serial data received].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        private void OnSerialComService_SerialDataReceived(object sender, SerialDataReceivedEventHandlerArgs args)
        {
            AppendToReceivedData(args.DataReceived);
        }


        #region BackgoundThreadSafeControlUpdates
        /// <summary>
        /// Appends to received data.
        /// </summary>
        /// <param name="dataReceived">The data received.</param>
        private void AppendToReceivedData(string dataReceived)
        {
            txtRecievedData.BeginInvoke((MethodInvoker)delegate ()
            {
                if (_applicationState.EnableTimestamps)
                {
                    dataReceived = DateTime.Now.ToString("yyyy-MM-dd - hh:mm:ss") + "\r\n" + dataReceived;
                }

                txtRecievedData.AppendText(dataReceived);

                if (_applicationState.AutoScrollText)
                {
                    txtRecievedData.ScrollToCaret();
                }
            });
        }

        /// <summary>
        /// Sets the status label text.
        /// </summary>
        /// <param name="text">The text.</param>
        private void SetStatusLabelText(string text)
        {
            statusStrip1.BeginInvoke((MethodInvoker)delegate ()
            {
                lblStatus.Text = text;
            });
        }


        #endregion



        /// <summary>
        /// Handles the Click event of the btnSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SerialConnectionSettings();
            var result = settingsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {

            }

            settingsForm.Dispose();
        }

        /// <summary>
        /// Clears the text received.
        /// </summary>
        private void ClearTextReceived()
        {
            txtRecievedData.Clear();
        }


        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextReceived();
        }

        /// <summary>
        /// Handles the Click event of the btnSend control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            _serialComService.SendTextLine(txtSendText.Text);
            txtSendText.Clear();

        }

        private void ConnectToFirstOpenComPort()
        {
            if (_serialComService.IsConnected)
            {
                lblStatus2.Text = "Error, already connected. Disconnect before making a new connection.";
                return;
            }

            int defBaudRate = Settings.Default.BaudRate;
            string portName = SerialComService.GetPortNamesAvailable().FirstOrDefault();

            if (string.IsNullOrEmpty(portName))
            {
                lblStatus2.Text = "Quick connect was not possible because no available ports where available.";
                return;
            }

            bool result = _serialComService.Connect(portName, defBaudRate);
            lblStatus2.Text = result ? "Quick Connect Successful" : "Quick connect failed.";
        }

        private void UpdateGuiFromAppState()
        {
            if (Thread.CurrentThread.IsBackground || Thread.CurrentThread.IsThreadPoolThread)
            {
                BeginInvoke((MethodInvoker)UpdateGuiUsingNativeThread);
            }
            else
            {
                UpdateGuiUsingNativeThread();
            }
        }


        private void UpdateGuiUsingNativeThread()
        {
            string statusText = "";
            if (_applicationState.Status == ConnectionStatus.Connected)
            {
                statusText = "Connected";
                btnSend.Enabled = true;
                btnQuickConnect.Enabled = false;
            }
            else if (_applicationState.Status == ConnectionStatus.Disconnected)
            {
                statusText = "Disconnected";
                btnSend.Enabled = false;
                btnQuickConnect.Enabled = true;
            }
            else if (_applicationState.Status == ConnectionStatus.None)
            {
                statusText = "Not Connected";
                btnSend.Enabled = false;
                btnQuickConnect.Enabled = true;
            }
            else
            {
                statusText = "Error";
                btnSend.Enabled = false;
                btnQuickConnect.Enabled = false;
            }

            chkShowTimeStamps.Checked = _applicationState.EnableTimestamps;
            chkAutoScroll.Checked = _applicationState.AutoScrollText;

            lblStatus.Text = statusText;
        }

        /// <summary>
        /// Handles the CheckStateChanged event of the chkAutoScroll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkAutoScroll_CheckStateChanged(object sender, EventArgs e)
        {
            _applicationState.AutoScrollText = chkAutoScroll.Checked;
        }

        /// <summary>
        /// Handles the CheckStateChanged event of the chkShowTimeStamps control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkShowTimeStamps_CheckStateChanged(object sender, EventArgs e)
        {
            _applicationState.EnableTimestamps = chkShowTimeStamps.Checked;
        }


        /// <summary>
        /// Handles the Click event of the btnExitApp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Quit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit(new CancelEventArgs(false));
            }
        }

        private void popupMenuReconnect_Click(object sender, EventArgs e)
        {

        }

        private void popupMenuDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void popupMenuOpenFile_Click(object sender, EventArgs e)
        {

        }

        private void popupMenuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = "Save output to text file";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                try
                {
                    txtRecievedData.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    txtRecievedData.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void popupMenuCopy_Click(object sender, EventArgs e)
        {
            if (txtRecievedData.SelectedRtf?.Length > 0)
            {
                Clipboard.Clear();
                Clipboard.SetText(txtRecievedData.SelectedRtf, TextDataFormat.Rtf);
            }
        }

        private void drpRowOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuickConnect_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Settings


            e.Cancel = false;

        }
    }
}
