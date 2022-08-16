using AutoMapper;
using StorageModule.Models;

namespace SerialMonitor.Configuration.AutomapperProfiles
{
    public class SerialMonitorMappingProfile : Profile
    {
        public SerialMonitorMappingProfile()
        {
            ApplicationSettingsModel.CreateMapping(this);
        }
    }
}