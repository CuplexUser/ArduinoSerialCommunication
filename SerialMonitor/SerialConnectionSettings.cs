using System;
using System.Windows.Forms;
using SerialMonitor.Service;

namespace SerialMonitor
{
    public partial class SerialConnectionSettings : Form
    {
        private readonly SerialComService _serialComService = SerialComService.Instance;
        private const string DefaultBaudRate = "115200";

        public SerialConnectionSettings()
        {
            InitializeComponent();
        }

        private void SerialConnectionSettings_Load(object sender, EventArgs e)
        {
            string[] names = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string name in names)
            {
                drpPorts.Items.Add(name);
            }

            if (names.Length > 0)
            {
                drpPorts.SelectedIndex = 0;
            }

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

        }

        public void Connect()
        {
            if (_serialComService.Connect(drpPorts.SelectedItem.ToString(), drpBaudRate.SelectedItem.ToString()))
            {
                txtStatus.AppendText("Connected" + "\r\n");
            }
            else
            {
                txtStatus.AppendText("ConnectionFailed\r\n" + _serialComService.LastError + "\r\n");
            }
        }

        public void Disconnect()
        {
            if (_serialComService.Disconnect())
            {
                txtStatus.AppendText("Disconnected" + "\r\n");
            }

        }

        public void RefreshCom()
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCom();
        }
    }
}
