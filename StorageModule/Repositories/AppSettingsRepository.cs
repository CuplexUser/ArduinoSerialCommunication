using System;
using System.IO;
using AutoMapper;
using Serilog;
using StorageModule.Configuration;
using StorageModule.Models;
using StorageModule.Models.Enums;

namespace StorageModule.Repositories
{
    public class AppSettingsRepository : RepositoryBase
    {
        private const string SettingsFilename = "SerialMonitorSettings.bin";
        private readonly string appConfigSettingsFilePath;
        private readonly IMapper _mapper;

        private static ApplicationSettingsModel GetDefaultSettings()
        {
            return new ApplicationSettingsModel { AutoScrollText = true, BaudRate = 9600, EnableTimestamps = true, Status = ConnectionStatus.None, AppSettingsGuid = Guid.NewGuid() };
        }

        public AppSettingsRepository(IMapper mapper)
        {
            _mapper = mapper;
            appConfigSettingsFilePath = Path.Combine(ApplicationBuildConfig.UserDataPath, SettingsFilename);
        }

        public ApplicationSettingsModel LoadAppSettings()
        {
            ApplicationSettingsModel model = null;

            if (File.Exists(appConfigSettingsFilePath))
            {

            }
            else
            {

            }

            try
            {

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load AppSettings from AppSettingsRepository");
            }

            if (model == null)
                model = GetDefaultSettings();

            return model;
        }

        public bool SaveAppSettings()
        {
            return true;
        }
    }
}