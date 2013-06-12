using Microsoft.Hadoop.MapReduce;
using Microsoft.Hadoop.MapReduce.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonToModelConverterJob.Extensions;
using Microsoft.Hadoop.MapReduce.HdfsExtras.Hdfs;
using System.IO;
using Microsoft.Hadoop.WebHDFS;
using Microsoft.Hadoop.WebHDFS.Adapters;

namespace JsonToModelConverterJob
{
    public class JsonToModelMapper
    {
        private const string DirectoryPath = "/user/Camper/Deliveries";

        public void Map(IEnumerable<Message> sensorMessages)
        {
            var groupedMessages = sensorMessages.GroupBy(msg => msg.DeliveryId);

            foreach (var group in groupedMessages)
            {
                var delivery = group.MapToDelivery();

                var client = new WebHDFSClient(new Uri(@"http://127.0.0.1:50070/"), "Camper");
                var remotePath = string.Format("{0}/{1}_{2}", DirectoryPath, delivery.Vehicle.VehicleId, group.Key);
                var memStream = new MemoryStream(SerializationHelper.Serialize(delivery));

                client.CreateFile(memStream,  remotePath).ContinueWith(tsk => memStream.Dispose());
            }
        }
    }
}
