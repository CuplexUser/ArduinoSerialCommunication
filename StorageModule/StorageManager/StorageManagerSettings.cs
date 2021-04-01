namespace StorageModule.StorageManager
{
    public sealed class StorageManagerSettings
    {
        public int NumberOfThreads { get; private set; }
        public bool UseMultithreading { get; private set; }
        public bool UseEncryption { get; private set; }
        public string Password { get; private set; }

        private StorageManagerSettings()
        {
            NumberOfThreads = 1;
        }

        public StorageManagerSettings(bool useMultithreading, int numberOfThreads, bool useEncryption, string password)
        {
            UseMultithreading = useMultithreading;
            NumberOfThreads = numberOfThreads;
            UseEncryption = useEncryption;
            Password = password;
        }

        public static StorageManagerSettings GetDefaultSettings()
        {
            StorageManagerSettings settings = new StorageManagerSettings
            {
                NumberOfThreads = 1,
                UseEncryption = false,
                Password = null,
                UseMultithreading = false,
            };

            return settings;
        }
    }
}