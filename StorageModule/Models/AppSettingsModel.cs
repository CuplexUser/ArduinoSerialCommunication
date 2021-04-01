using StorageModule.Models.Enums;

namespace StorageModule.Models
{
    public class AppSettingsModel
    {
        public AppSettingsModel()
        {
            Status = ConnectionStatus.None;
        }

        public ConnectionStatus Status { get; set; }

        public bool AutoScrollText { get; set; }

        public bool EnableTimestamps { get; set; }

        public int BaudRate { get; set; }


        //public static void CreateMapping(IProfileExpression expression)
        //{
        //    expression.CreateMap<AppSettingsDataModel, AppSettingsModel>()
        //              .ForMember(s => s.AutoScrollText, o => o.MapFrom(d => d.AutoScrollText))
        //              .ForMember(s => s.BaudRate, o => o.MapFrom(d => d.BaudRate))
        //              .ForMember(s => s.EnableTimestamps, o => o.MapFrom(d => d.EnableTimestamps))
        //              .ForMember(s => s.Status, o => o.MapFrom<ConnectionStatusModel>(d.ConnectionStatus=>d.ConnectionStatus = o.ConvertUsing())
                     
        //}

        //public Expression   <Func<ConnectionStatus,ConnectionStatus>>()
    }
}