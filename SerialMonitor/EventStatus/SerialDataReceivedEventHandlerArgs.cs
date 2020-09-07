using System;

namespace SerialMonitor.Service
{
    /// <summary>
    /// </summary>
    public class SerialDataReceivedEventHandlerArgs : EventArgs
    {
        public SerialDataReceivedEventHandlerArgs(string serialDataReceived)
        {
            DataReceived = serialDataReceived;
        }

        public string DataReceived { get; private set; }
    }
}