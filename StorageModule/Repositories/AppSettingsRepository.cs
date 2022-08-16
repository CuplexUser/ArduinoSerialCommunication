using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using AutoMapper;
using AutoMapper.Internal;
using GeneralToolkitLib.Converters;
using GeneralToolkitLib.Storage;
using GeneralToolkitLib.Storage.Models;
using GeneralToolkitLib.Utility.RandomGenerator;
using Serilog;
using StorageModule.Configuration;
using StorageModule.DataModels;
using StorageModule.Models;
using StorageModule.Models.Enums;

namespace StorageModule.Repositories
{
    public class AppSettingsRepository : RepositoryBase
    {
        private const string SettingsFilename = "SerialMonitorSettings.bin";
        private readonly string appConfigSettingsFilePath;
        private readonly IMapper _mapper;
        private readonly IStorageManager _storageManager;
        private const string Keyparam = "EEB9AF0318D3490E96F426F3FD5C12F4";
        private readonly byte[] SaltBytes = { 0xCF, 0xA4, 0xB0, 0xBB, 0x92, 0xF2, 0x60, 0x86, 0x49, 0x80, 0xB7, 0xE1, 0x6E, 0x46, 0x89, 0x1A,
            0xC3, 0x57, 0x76, 0x3E, 0x53, 0x9A, 0xBE, 0x6D, 0x97, 0xF2, 0x61, 0x63, 0xBF, 0x32, 0x79, 0xCE };

        private static ApplicationSettingsModel GetDefaultSettings()
        {
            return new ApplicationSettingsModel { AutoScrollText = true, BaudRate = 9600, EnableTimestamps = true, Status = ConnectionStatus.None, AppSettingsGuid = Guid.NewGuid() };
        }

        public AppSettingsRepository(IMapper mapper)
        {
            _mapper = mapper;
            var settings = new StorageManagerSettings(false, 8, true, GetStringPassword());
            _storageManager = new StorageManager(settings);
            appConfigSettingsFilePath = Path.Combine(ApplicationBuildConfig.UserDataPath, SettingsFilename);
        }

        public ApplicationSettingsModel LoadAppSettings()
        {
            ApplicationSettingsModel model = null;

            try
            {
                if (File.Exists(appConfigSettingsFilePath))
                {
                    var settingsDataModel = _storageManager.DeserializeObjectFromFile<ApplicationSettingsDataModel>(appConfigSettingsFilePath, null);
                    if (settingsDataModel != null)
                    {
                        model = _mapper.Map<ApplicationSettingsModel>(settingsDataModel);
                        return model;
                    }
                }

                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load AppSettings from AppSettingsRepository");
            }

            return model ?? (model = GetDefaultSettings());
        }

        [SecuritySafeCritical]
        private string GetStringPassword()
        {
            var derivedKey = new Rfc2898DeriveBytes(Keyparam, SaltBytes, 5049);
            var buffer = derivedKey.GetBytes(32);

            return Convert.ToBase64String(buffer);
        }

        public bool SaveAppSettings(ApplicationSettingsModel settings)
        {
            try
            {
                var settingsDataModel = _mapper.Map<ApplicationSettingsDataModel>(settings);
                return _storageManager.SerializeObjectToFile(settingsDataModel, appConfigSettingsFilePath, null);

            }
            catch (Exception exception)
            {
                Log.Error(exception, "SaveAppSettings failed.Settings model: {@SettingsModel}", settings);
            }

            return false;
        }

        internal void CreateRndBufferStruct()
        {
            byte[] rndData = new SecureRandomGenerator().GetRandomData(256);
            string strRep = GeneralConverters.ByteArrayToHexString(rndData);
        }
    }
}