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
        public static void Serialize<T>(T data, Stream stream) where T : TBase
        {
            using (var thriftTransport = new TStreamTransport(null, stream))
            {
                var binaryProtocol = new TBinaryProtocol(thriftTransport);
                data.Write(binaryProtocol);
            }
        }

        public static T Deserialize<T>(Stream stream) where T : TBase, new()
        {
            using (var thriftTransport = new TStreamTransport(stream, null))
            {
                var binaryProtocol = new TBinaryProtocol(thriftTransport);

                var person = new T();
                person.Read(binaryProtocol);

                return (T)person;
            }
        }
    }
}
