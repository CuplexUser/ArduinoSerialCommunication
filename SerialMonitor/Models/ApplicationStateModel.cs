using System.Runtime.Serialization;
using SerialMonitor.Enums;

namespace SerialMonitor.Models
{
    [DataContract(Name = "ApplicationStateModel")]
    public class ApplicationStateModel
    {
        [DataMember(Name = "Status", Order = 1)]
        public ConnectionStatus Status { get; set; }

        [DataMember(Name = "AutoScrollText", Order = 2)]
        public bool AutoScrollText { get; set; }

        [DataMember(Name = "EnableTimestamps", Order = 3)]
        public bool EnableTimestamps { get; set; }

        [DataMember(Name = "BaudRate", Order = 4)]
        public int BaudRate { get; set; }

        public ApplicationStateModel()
        {
            Status = ConnectionStatus.None;
        }
    }
}
