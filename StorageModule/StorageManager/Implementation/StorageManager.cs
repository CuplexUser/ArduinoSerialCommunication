using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageModule.StorageManager.Implementation
{
    public class StorageManager : StorageManagerBase, IStorageManager
    {
        public bool SerializeObjectToFile(object obj, string filename, IProgress<StorageManagerProgress> progress)
        {
            return false;
        }

        public Task<bool> SerializeObjectToFileAsync(object obj, string path, IProgress<StorageManagerProgress> progress)
        {
            return null;
        }

        public T DeserializeObjectFromFile<T>(string path, IProgress<StorageManagerProgress> progress)
        {
            return default;
        }

        public Task<T> DeserializeObjectFromFileAsync<T>(string path, IProgress<StorageManagerProgress> progress)
        {
            return null;
        }

        public bool CompressFile(List<string> filesToCompress, string outputFile, IProgress<StorageManagerProgress> progress)
        {
            return false;
        }

        public Task<bool> CompressFileAsync(List<string> filesToCompress, string outputFile, IProgress<StorageManagerProgress> progress)
        {
            return null;
        }
    }
}