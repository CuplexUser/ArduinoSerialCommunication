using System;
using SerialMonitor.Enums;

namespace SerialMonitor.EventStatus
{

   public class SerialConStatusChangedEventArgs : EventArgs
    {


        public SerialConStatusChangedEventArgs(ConnectionStatusChange connectionStatus)
        {
            ActiveStatus = connectionStatus;
        }

        public SerialConStatusChangedEventArgs(ConnectionStatusChange status, string message)
        {
            ActiveStatus = status;
            Message = message;
        }

        public ConnectionStatusChange ActiveStatus { get; private set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(ActiveStatus)}: {ActiveStatus}";
        }
    }
}