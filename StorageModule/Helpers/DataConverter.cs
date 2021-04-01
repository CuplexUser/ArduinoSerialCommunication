using System;
using System.Linq;
using System.Text;

namespace StorageModule.Helpers
{
    public static class DataConverter
    {
        public static string ByteArrayToHexString(byte[] data)
        {
            var sb = new StringBuilder();
            foreach (byte b in data)
                sb.AppendFormat("{0:X2}", b);

            return sb.ToString();
        }

        public static byte[] GetByteArrayFromString(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetStringFromByteArray(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }


        public static string ByteArrayToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}