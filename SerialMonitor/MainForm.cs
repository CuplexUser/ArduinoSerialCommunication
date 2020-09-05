using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialMonitor.Service;

namespace SerialMonitor
{
    public partial class MainForm : Form
    {
        private readonly SerialComService _serialComService = SerialComService.Instance;
        public MainForm()
        {
            InitializeComponent();
        }



        private void spContainer_Resize(object sender, EventArgs e)
        {
            spContainer.PerformAutoScale();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _serialComService.SerialDataReceived += OnSerialComService_SerialDataReceived;
        }

        private void OnSerialComService_SerialDataReceived(object sender, SerialDataReceivedEventHandlerArgs args)
        {
            this.Invoke(new SerialDataReceivedEventHandler(AppendTextReceivedUiThreadExec),this, args);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SerialConnectionSettings();
            var result = settingsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {

            }

            settingsForm.Dispose();
        }

        private void ClearTextReceived()
        {
            txtRecievedData.Clear();
        }



        private void AppendTextReceivedUiThreadExec(object sender, SerialDataReceivedEventHandlerArgs args)
        {
            txtRecievedData.AppendText(args.DataReceived);
        }
        //{

        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextReceived();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
