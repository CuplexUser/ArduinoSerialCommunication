using System;
using StorageModule.Models.Enums;

namespace SerialMonitor.EventStatus
{

   public class SerialConnectionStateEventArgs : EventArgs
    {
        public SerialConnectionStateEventArgs(ConnectionStatus connectionStatus)
        {
            ActiveStatus = connectionStatus;
        }

        public SerialConnectionStateEventArgs(ConnectionStatus status, string message)
        {
            ActiveStatus = status;
            Message = message;
        }

        public ConnectionStatus ActiveStatus { get; private set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(ActiveStatus)}: {ActiveStatus}";
        }
    }
}