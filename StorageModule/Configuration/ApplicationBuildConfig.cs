using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace StorageModule.Configuration
{
    public static class ApplicationBuildConfig
    {
        private static string _userDataPath;
        private static Assembly _serialMonitorAssembly;

        public static string ApplicationLogFilePath() => Path.Combine(UserDataPath, $"{Application.ProductName}-{DateTime.Today.ToString("yyyy-MM-dd")}.log");

        public static string UserDataPath => _userDataPath ?? (_userDataPath = GetUserDataPath());

        public static bool DebugMode => IsDebug(Assembly.GetCallingAssembly());

        private static string GetUserDataPath() => DebugMode ? GetAssemblyPath() :
            Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.CompanyName, Application.ProductName);

        // Used in debug mode when the log file is created in the same directory as the Main Executring Assembly
        public static void SetOverrideUserDataPath(string path) => _userDataPath = path;

        private static string GetAssemblyPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        private static bool IsDebug(Assembly assembly)
        {
            object[] customAttributes = assembly.GetCustomAttributes(typeof(DebuggableAttribute), true);
            return customAttributes.Length == 0 || ((DebuggableAttribute)customAttributes[0]).IsJITTrackingEnabled;
        }

        public static Assembly SerialMonitorAssembly
        {
            get => _serialMonitorAssembly;
            set
            {
                // Set once aka init
                if (_serialMonitorAssembly == null && value != null)
                {
                    _serialMonitorAssembly = value;
                }

            }
        }
    }
}