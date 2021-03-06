﻿using System;

namespace SerialMonitor.EventStatus
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