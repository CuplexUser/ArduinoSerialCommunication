using System.Reflection;

namespace StorageModule.Helpers
{
    public static class AssemblyHelper
    {
        public static string GetNameOfThisAssembly() => Assembly.GetExecutingAssembly().GetName().Name;

        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}