using System;
using AutoMapper;
using Serilog;
using StorageModule.Models;
using StorageModule.Repositories;

namespace StorageModule.Services
{
    public class ApplicationSettingsService : ServiceBase
    {
        private ApplicationSettingsModel _applicationSettingsModel;
        private readonly AppSettingsRepository _appSettingsRepo;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ApplicationSettingsModel Settings => _applicationSettingsModel ?? (_applicationSettingsModel = LoadLocalStorageSettings());

        public ApplicationSettingsService(IMapper mapper, ILogger logger, AppSettingsRepository appSettingsRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _appSettingsRepo = appSettingsRepo;
        }


        public bool LoadSettings()
        {
            string settingsFilePath = "";
            try
            {
                _applicationSettingsModel = _appSettingsRepo.LoadAppSettings();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed Loading Settings from filePath: {settingsFilePath}", settingsFilePath);
                return false;
            }

            return true;
        }

        private ApplicationSettingsModel LoadLocalStorageSettings()
        {
            LoadSettings();

            return _applicationSettingsModel;
        }

        public bool SaveSettings()
        {
            return true;
        }
    }
}