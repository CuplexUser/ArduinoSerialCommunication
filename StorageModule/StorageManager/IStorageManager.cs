using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageModule.StorageManager
{
    /// <summary>
    ///  StorageManager interface
    /// </summary>
    public interface IStorageManager
    {
        /// <summary>
        /// Serializes the object to file.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        bool SerializeObjectToFile(object obj, string filename, IProgress<StorageManagerProgress> progress);
        /// <summary>
        /// Serializes the object to file asynchronous.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="path">The path.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        Task<bool> SerializeObjectToFileAsync(object obj, string path, IProgress<StorageManagerProgress> progress);
        /// <summary>
        /// Deserializes the object from file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        T DeserializeObjectFromFile<T>(string path, IProgress<StorageManagerProgress> progress);
        /// <summary>
        /// Deserializes the object from file asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        Task<T> DeserializeObjectFromFileAsync<T>(string path, IProgress<StorageManagerProgress> progress);
        /// <summary>
        /// Compresses the file.
        /// </summary>
        /// <param name="filesToCompress">The files to compress.</param>
        /// <param name="outputFile">The output file.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        bool CompressFile(List<string> filesToCompress, string outputFile, IProgress<StorageManagerProgress> progress);
        /// <summary>
        /// Compresses the file asynchronous.
        /// </summary>
        /// <param name="filesToCompress">The files to compress.</param>
        /// <param name="outputFile">The output file.</param>
        /// <param name="progress">The progress.</param>
        /// <returns></returns>
        Task<bool> CompressFileAsync(List<string> filesToCompress, string outputFile, IProgress<StorageManagerProgress> progress);
    }
}