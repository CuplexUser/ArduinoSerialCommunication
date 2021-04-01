using System.ComponentModel;
using System.Runtime.Serialization;

namespace StorageModule.DataModels
{
    [DataContract(Name = "AppSettingsDataModel")]
    public class AppSettingsDataModel
    {
        [DataMember(Name = "Status", Order = 1)]
        [DefaultValue((int)ConnectionStatusModel.None)]
        public int ConnectionStatus { get; set; }

        [DataMember(Name = "AutoScrollText", Order = 2)]
        public bool AutoScrollText { get; set; }

        [DataMember(Name = "EnableTimestamps", Order = 3)]
        public bool EnableTimestamps { get; set; }

        [DataMember(Name = "BaudRate", Order = 4)]
        public int BaudRate { get; set; }

        public AppSettingsDataModel()
        {
            ConnectionStatus = (int)ConnectionStatusModel.None;
        }

        
    }
}
