using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using ProtoBuf;
using StorageModule.Helpers;

namespace StorageModule.Serializers
{
    public class ObjectSerializer<T>
    {
        public T DeserializeObjectFromByteArray(byte[] byteData)
        {
            return DeserializeProtoBufferObjectDataInternal(byteData);
        }

        public T DeserializeObjectFromString(string data, StringSerializationFormat format, bool useProtobuffer=true)
        {
            byte[] byteData = null;
            switch (format)
            {
                case StringSerializationFormat.Base64:
                    byteData = Convert.FromBase64String(data);
                    break;
                case StringSerializationFormat.Hex:
                    byteData = DataConverter.HexStringToByteArray(data);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format));
            }

            if (!useProtobuffer)
                throw new ArgumentException("Only protobuffer Deserialization is supported");

            return  DeserializeProtoBufferObjectDataInternal(byteData);
        }

        public byte[] SerializeToByteArray(T obj)
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(obj.GetType());
            bool protoBufferCompatible = attrs.OfType<DataContractAttribute>().Any();

            if (protoBufferCompatible)
                return SerializeUsingProtoBuffersInternal(obj);
            throw new ArgumentException($"obj of type({obj.GetType()}) Could not be Serialized");
        }

        #region Private Byte Array layer

        private byte[] SerializeUsingProtoBuffersInternal(T serializableObject)
        {
            MemoryStream ms = new MemoryStream();
            Serializer.NonGeneric.Serialize(ms, serializableObject);
            return ms.ToArray();
        }

        private T DeserializeProtoBufferObjectDataInternal(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return Serializer.Deserialize<T>(ms);
        }

        #endregion

        public enum StringSerializationFormat
        {
            Base64,
            Hex,
        }
    }
}