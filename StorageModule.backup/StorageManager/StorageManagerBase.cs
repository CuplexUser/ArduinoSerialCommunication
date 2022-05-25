using System;
using System.IO;

namespace StorageModule.StorageManager
{
    public abstract class StorageManagerBase
    {
        protected static void CreateFilePathIfItDoesNotExist(string fullPath)
        {
            string directoryPath = GetDirectoryFromFullPath(fullPath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        private static string GetDirectoryFromFullPath(string fullPath)
        {
            int lastIndex = fullPath.LastIndexOf("\\", StringComparison.Ordinal);
            if (lastIndex > 0)
                return fullPath.Substring(0, lastIndex);

            return fullPath;
        }
    }
}