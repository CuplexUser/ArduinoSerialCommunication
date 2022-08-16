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

        public string NewlineOption { get; set; }

        public string SelectedComPort { get; set; }
        
        public static void CreateMapping(IProfileExpression expression)
        {
            expression.CreateMap<ApplicationSettingsDataModel, ApplicationSettingsModel>()
                .ForMember(s => s.AutoScrollText, o => o.MapFrom(d => d.AutoScrollText))
                .ForMember(s => s.BaudRate, o => o.MapFrom(d => d.BaudRate))
                .ForMember(s => s.EnableTimestamps, o => o.MapFrom(d => d.EnableTimestamps))
                .ForMember(s => s.NewlineOption, o => o.MapFrom(d => d.NewlineOption))
                .ForMember(s => s.Status, o => o.Ignore())
                .ForMember(s => s.SelectedComPort, o => o.MapFrom(d => d.SelectedComPort))
                .ReverseMap()
                .ForMember(s => s.SelectedComPort, o => o.MapFrom(d => d.SelectedComPort))
                .ForMember(s => s.ConnectionStatus, o => o.MapFrom(d => (int) d.Status))
                .ForMember(s => s.NewlineOption, o => o.MapFrom(d => d.SelectedComPort));
        }
    }
}