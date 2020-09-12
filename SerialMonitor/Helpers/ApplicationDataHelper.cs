using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace SerialMonitor.Helpers
{
    public class ApplicationDataHelper
    {
        public static string GetMainFormTitle()
        {
            var assemblyBuildInfo = Application.ProductName;
            string title = Application.ProductName + " - " + Application.ProductVersion;

            return title;
        }
        

    }
    
    public class StaticDataSources
    {
        public static object[] NewlineOptions = { "Newline", "Newline+CR", "Null character" };
    }
}