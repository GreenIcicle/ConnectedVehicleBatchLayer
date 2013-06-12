using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace JsonToModelConverterJob
{
    public static class SerializationHelper
    {
        public static byte[] Serialize<T>(T data) where T : TBase
        {
            using (var memStream = new MemoryStream())
            using (var binaryReader = new BinaryReader(memStream))
            using (var thriftTransport = new TStreamTransport(null, memStream))
            {
                var binaryProtocol = new TCompactProtocol(thriftTransport);
                data.Write(binaryProtocol);

                //TODO Refactor
                memStream.Position = 0;
                return binaryReader.ReadBytes((int)memStream.Length);
            }
        }

        public static T Deserialize<T>(Stream stream) where T : TBase, new()
        {
            using (var thriftTransport = new TStreamTransport(stream, null))
            {
                var binaryProtocol = new TCompactProtocol(thriftTransport);

                var person = new T();
                person.Read(binaryProtocol);

                return (T)person;
            }
        }
    }
}
