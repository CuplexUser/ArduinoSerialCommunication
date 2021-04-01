namespace StorageModule.Models.Enums
{
    public enum ConnectionStatus : int
    {
        None = 0,
        Disconnected = 1,
        Connected = 2,
        Error = 3,
    }

    //public EnumToEnumMapper ConvertEnumValue(ConnectionStatus model1, DataModels.ConnectionStatusModel model2) => 

}