﻿using System;
using System.Windows.Forms;
using SerialMonitor.Helpers;
using SerialMonitor.Service;

namespace SerialMonitor
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SerialConnectionSettings : Form
    {
        /// <summary>
        /// The serial COM service
        /// </summary>
        private readonly SerialComService _serialComService = SerialComService.Instance;
        /// <summary>
        /// The default baud rate
        /// </summary>
        private const string DefaultBaudRate = "115200";

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialConnectionSettings"/> class.
        /// </summary>
        public SerialConnectionSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SerialConnectionSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SerialConnectionSettings_Load(object sender, EventArgs e)
        {
            PopulateComDrpList();

            var rates = _serialComService.GetBaudRates();
            foreach (string rate in rates)
            {
                drpBaudRate.Items.Add(rate);
            }

            drpBaudRate.SelectedIndex = 0;


            for (int i = 0; i < drpBaudRate.Items.Count; i++)
            {
                if (drpBaudRate.Items[i].ToString() == DefaultBaudRate)
                {
                    drpBaudRate.SelectedIndex = i;
                    break;
                }
            }

            InitNewlineOptions();

        }

        private void PopulateComDrpList()
        {
            drpPorts.Items.Clear();
            var names = SerialComService.GetPortNamesAvailable();

            foreach (string name in names)
            {
                drpPorts.Items.Add(name);
            }

            if (names.Length > 0)
            {
                drpPorts.SelectedIndex = 0;
            }
        }

        private void InitNewlineOptions()
        {
            drpRowOptions.DataSource = StaticDataSources.NewlineOptions;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        private void Connect()
        {
            if (_serialComService.IsConnected)
            {
                AppendStatusText("Already connected!");
                return;
            }

            if (drpPorts.Items.Count == 0)
            {
                MessageBox.Show("No available Com Ports", "Unable to connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int baudRate = Convert.ToInt32(drpBaudRate.SelectedItem.ToString());
            string comPort = drpPorts.SelectedItem.ToString();

            if (_serialComService.Connect(comPort, baudRate))
            {
                AppendStatusText("Connected");
            }
            else
            {
                AppendStatusText("ConnectionFailed: " + _serialComService.LastError);
            }
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        private void Disconnect()
        {
            if (_serialComService.Disconnect())
            {
                AppendStatusText("Disconnected");
            }

        }

        /// <summary>
        /// Refreshes the COM.
        /// </summary>
        private void RefreshCom()
        {
            PopulateComDrpList();
            AppendStatusText("Refreshed Com port List");
        }

        /// <summary>
        /// Appends the status text.
        /// </summary>
        /// <param name="text">The text.</param>
        private void AppendStatusText(string text)
        {
            txtStatus.AppendText(text + "\r\n");
        }

        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        /// <summary>
        /// Handles the Click event of the btnDisconnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        /// <summary>
        /// Handles the Click event of the btnRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCom();
        }

    }
}
