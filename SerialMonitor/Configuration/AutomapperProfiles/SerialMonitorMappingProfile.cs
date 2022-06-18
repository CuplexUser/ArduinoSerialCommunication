using AutoMapper;
using StorageModule.Models;

namespace StorageModule.Configuration.AutomapperProfile
{
    public class SerialMonitorMappingProfile : Profile
    {
        public SerialMonitorMappingProfile()
        {
            ApplicationSettingsModel.CreateMapping(this);
        }
    }
}