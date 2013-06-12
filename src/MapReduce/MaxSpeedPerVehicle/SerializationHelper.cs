using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.MaxSpeedPerVehicle
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(Stream stream) where T : TBase, new()
        {
            using (var thriftTransport = new TStreamTransport(stream, null))
            {
                var binaryProtocol = new TBinaryProtocol(thriftTransport);

                var person = new T();
                person.Read(binaryProtocol);

                return person;
            }
        }

        public static T Deserialize<T>(string content) where T : TBase, new()
        {
            using (var memStream = new MemoryStream(GetBytes(content)))
            {
                return Deserialize<T>(memStream);
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
