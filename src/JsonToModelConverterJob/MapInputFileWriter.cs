using Microsoft.Hadoop.WebHDFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonToModelConverterJob
{
    public class MapInputFileWriter
    {      
        private const string DirectoryPath = "/user/Camper/Deliveries-tsv";

        public void Write(IEnumerable<Message> messages)
        {
            var sensorData = messages
                .OrderBy(msg => msg.VehicleId)
                .ThenBy(msg => msg.Timestamp)
                .Select(msg => msg.Serialize());
            var content = string.Join("\n", sensorData);
            
            var client = new WebHDFSClient(new Uri(@"http://127.0.0.1:50070/"), "Camper");
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            string remoteFile = DirectoryPath + "/SensorData";
            var task = client.CreateFile(memStream, remoteFile);
            task.Wait();
        }
    }
}
