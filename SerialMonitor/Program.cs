using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SerialMonitor.Configuration;
using Serilog;
using StorageModule.Configuration;
using StorageModule.Services;

namespace SerialMonitor
{
    static class Program
    {
        private static IContainer Container { get; set; }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationBuildConfig.SerialMonitorAssembly = Assembly.GetExecutingAssembly();
            InitializeAutofac();

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(true);
            bool debugMode = ApplicationBuildConfig.DebugMode;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log.Verbose("Application started");

            using (var scope = Container.BeginLifetimeScope())
            {
                // Begin startup async jobs
                ApplicationSettingsService settingsService = scope.Resolve<ApplicationSettingsService>();


                bool readSuccessful = settingsService.LoadSettings();

                if (!readSuccessful)
                {
                    string userDataPath = ApplicationBuildConfig.UserDataPath;
                    Log.Error("Failed to load application settings on program load. User data path {userDataPath}", userDataPath);
                }



                Task.Delay(100);
                try
                {
                    MainForm frmMain = scope.Resolve<MainForm>();
                    Application.Run(frmMain);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Main program failureException: {Message}", ex.Message);
                }
            }
        }

        private static void InitializeAutofac()
        {
            Container = AutofacConfig.CreateContainer();
        }
    }
}
