using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace StorageModule.Configuration
{
    public static class ApplicationBuildConfig
    {
        private static string _userDataPath;
        private static Assembly _serialMonitorAssembly;

        public static string ApplicationLogFilePath() => Path.Combine(ApplicationBuildConfig.UserDataPath, Assembly.GetCallingAssembly().GetName().Name + DateTime.Today.ToString("yyyy-MM-dd") + ".log");

        public static string UserDataPath => ApplicationBuildConfig._userDataPath ?? (ApplicationBuildConfig._userDataPath = ApplicationBuildConfig.GetUserDataPath());

        public static bool DebugMode => ApplicationBuildConfig.IsDebug(Assembly.GetCallingAssembly());

        private static string GetUserDataPath() => ApplicationBuildConfig.DebugMode ? ApplicationBuildConfig.GetAssemblyPath(Assembly.GetExecutingAssembly().Location) : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Assembly.GetEntryAssembly()?.GetName().Name.Replace(" ", "") + "\\";

        // Used in debug mode when the log file is created in the same directory as the Main Executring Assembly
        public static void SetOverrideUserDataPath(string path) => ApplicationBuildConfig._userDataPath = path;

        private static string GetAssemblyPath(string fullAssemblyPath)
        {
            if (fullAssemblyPath != null)
            {
                int num = fullAssemblyPath.LastIndexOf('\\');
                if (num > 0)
                    return fullAssemblyPath.Substring(0, num + 1);
            }
            return (string)null;
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