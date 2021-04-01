using System.IO;
using System.Security.Cryptography;
using StorageModule.Helpers;

namespace StorageModule.Encryption.Hashing
{
    public class SHA512Impl : IHashTransform
    {
        public byte[] ComputeHash(Stream inputStream)
        {
            SHA512 sha512Implementation = SHA512.Create();
            return sha512Implementation.ComputeHash(inputStream);
        }

        public int HashSize => 512;

        public static string GetSHA512HashAsHexString(string inputString)
        {
            return GetSHA512HashAsHexString(DataConverter.GetByteArrayFromString(inputString));
        }

        public static string GetSHA512HashAsHexString(byte[] data)
        {
            SHA256 sha512Implementation = SHA256.Create();
            var hashData = sha512Implementation.ComputeHash(data);
            return DataConverter.ByteArrayToHexString(hashData);
        }

        public static byte[] GetSHA512HashAsByteArray(byte[] data)
        {
            SHA256 sha512Implementation = SHA256.Create();
            return sha512Implementation.ComputeHash(data);
        }
    }
}