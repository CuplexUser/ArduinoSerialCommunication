using System.Security;

namespace StorageModule.StorageManager.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageManagerSettings
    {
        /// <summary>
        /// Gets or sets the number of threads.
        /// </summary>
        /// <value>
        /// The number of threads.
        /// </value>
        public int NumberOfThreads { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [use multithreading].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use multithreading]; otherwise, <c>false</c>.
        /// </value>
        public bool UseMultithreading { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [use encryption].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use encryption]; otherwise, <c>false</c>.
        /// </value>
        public bool UseEncryption { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; private set; }



        public StorageManagerSettings()
        {
            NumberOfThreads = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageManagerSettings"/> class.
        /// </summary>
        /// <param name="useMultithreading">if set to <c>true</c> [use multithreading].</param>
        /// <param name="numberOfThreads">The number of threads.</param>
        /// <param name="useEncryption">if set to <c>true</c> [use encryption].</param>
        /// <param name="password">The password.</param>
        public StorageManagerSettings(bool useMultithreading, int numberOfThreads, bool useEncryption, string password)
        {
            UseMultithreading = useMultithreading;
            NumberOfThreads = numberOfThreads;
            UseEncryption = useEncryption;
            Password = password;
        }

        /// <summary>
        /// Gets the default settings.
        /// </summary>
        /// <returns></returns>
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
