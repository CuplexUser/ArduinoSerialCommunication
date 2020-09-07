using System;
using System.ComponentModel;
using System.Windows.Forms;
using SerialMonitor.Enums;
using SerialMonitor.Helpers;
using SerialMonitor.Service;

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
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
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
        }

        /// <summary>
        /// Handles the SerialConnectionStateChanged event of the _serialComService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="EventStatus.SerialConStatusChangedEventArgs"/> instance containing the event data.</param>
        private void _serialComService_SerialConnectionStateChanged(object sender, EventStatus.SerialConStatusChangedEventArgs args)
        {
            string statusText = "";
            if (args.ActiveStatus == ConnectionStatusChange.Connected)
            {
                statusText = "Connected";
            }
            else if (args.ActiveStatus == ConnectionStatusChange.Disconnected)
            {
                statusText = "Disconnected";
            }
            else
            {
                statusText = "Error";
                AppendToReceivedData(args.Message + "\r\n");
            }

            SetStatusLabelText(statusText);
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
                txtRecievedData.AppendText(dataReceived);
                if (chkAutoScroll.Checked)
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

        /// <summary>
        /// Handles the CheckStateChanged event of the chkAutoScroll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkAutoScroll_CheckStateChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the CheckStateChanged event of the chkShowTimeStamps control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkShowTimeStamps_CheckStateChanged(object sender, EventArgs e)
        {

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
    }
}
