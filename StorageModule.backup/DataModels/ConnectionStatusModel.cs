using System;

namespace StorageModule.DataModels
{
    [Serializable]
    public enum ConnectionStatusModel : int
    {
        None = 0,
        Disconnected = 1,
        Connected = 2,
        Error = 3,

    }
}
