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
            var sensorData =
                messages.OrderBy(msg => msg.VehicleId)
                        .ThenBy(msg => msg.Timestamp)
                        .Select(msg => msg.Serialize())
                        .ToArray();

            const int chunkSize = 50000;
            var maxIndex = (int)(Math.Ceiling(sensorData.Length / (double)chunkSize));

            var client = new WebHDFSClient(new Uri(@"http://127.0.0.1:50070/"), "Camper");

            for (int index = 0; index < maxIndex; index++)
            {
                var chunk = sensorData.Skip(index * chunkSize).Take(chunkSize);
                var content = string.Join("\n", chunk);
                var memStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                string remoteFile = string.Format("{0}/SensorData_{1}", DirectoryPath, index + 1);
                var task = client.CreateFile(memStream, remoteFile);
                task.Wait();

            }
        }
    }
}
