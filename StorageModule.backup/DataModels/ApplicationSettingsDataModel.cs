using System.ComponentModel;
using System.Runtime.Serialization;

namespace StorageModule.DataModels
{
    [DataContract(Name = "ApplicationSettingsDataModel", Namespace = "StorageModule.DataModels")]
    public class ApplicationSettingsDataModel
    {
        [DataMember(Name = "ConnectionStatus", Order = 1)]
        [DefaultValue((int)ConnectionStatusModel.None)]
        public int ConnectionStatus { get; set; }

        [DataMember(Name = "AutoScrollText", Order = 2)]
        public bool AutoScrollText { get; set; }

        [DataMember(Name = "EnableTimestamps", Order = 3)]
        public bool EnableTimestamps { get; set; }

        [DataMember(Name = "BaudRate", Order = 4)]
        public int BaudRate { get; set; }

    }
}
