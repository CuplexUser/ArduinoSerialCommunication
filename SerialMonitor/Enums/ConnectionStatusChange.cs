using System;

namespace SerialMonitor.Enums
{
    [Serializable]
    public enum ConnectionStatus
    {
        None = 0,
        Disconnected = 1,
        Connected = 2,
        Error = 0,

    }
}