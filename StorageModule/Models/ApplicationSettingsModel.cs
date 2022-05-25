using System;
using AutoMapper;
using StorageModule.DataModels;
using StorageModule.Models.Enums;

namespace StorageModule.Models
{
    public class ApplicationSettingsModel
    {
        public ApplicationSettingsModel()
        {
            Status = ConnectionStatus.None;
        }

        public Guid AppSettingsGuid { get; set; }

        public ConnectionStatus Status { get; set; }

        public bool AutoScrollText { get; set; }

        public bool EnableTimestamps { get; set; }

        public int BaudRate { get; set; }


        public static void CreateMapping(IProfileExpression expression)
        {
            expression.CreateMap<ApplicationSettingsDataModel, ApplicationSettingsModel>()
                .ForMember(s => s.AutoScrollText, o => o.MapFrom(d => d.AutoScrollText))
                .ForMember(s => s.BaudRate, o => o.MapFrom(d => d.BaudRate))
                .ForMember(s => s.EnableTimestamps, o => o.MapFrom(d => d.EnableTimestamps))
                .ForMember(s => s.Status, o => o.Ignore())
                .ReverseMap();
        }
    }
}