using System.IO;
using System.Security.Cryptography;
using StorageModule.Helpers;

namespace StorageModule.Encryption.Hashing
{
    public class SHA256Impl : IHashTransform
    {
        public byte[] ComputeHash(Stream inputStream)
        {
            SHA256 sha256Implementation = SHA256.Create();
            return sha256Implementation.ComputeHash(inputStream);
        }

        public int HashSize => 256;

        public static string GetSHA256HashAsHexString(byte[] data)
        {
            SHA256 sha256Implementation = SHA256.Create();
            var hashData = sha256Implementation.ComputeHash(data);
            return DataConverter.ByteArrayToHexString(hashData);
        }

        public static string GetSHA256HashAsHexString(string inputString)
        {
            return GetSHA256HashAsHexString(DataConverter.GetByteArrayFromString(inputString));
        }

        public static byte[] GetSHA256HashAsByteArray(byte[] data)
        {
            SHA256 sha256Implementation = SHA256.Create();
            return sha256Implementation.ComputeHash(data);
        }
    }
}