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
    public class JsonToModelMapper : JsonInMapperBase<IEnumerable<Message>>
    {
        private const string DirectoryPath = "/user/Camper/output/Deliveries";

        public override void Map(IEnumerable<Message> sensorMessages, MapperContext context)
        {
            var groupedMessages = sensorMessages.GroupBy(msg => msg.DeliveryId);

            foreach (var group in groupedMessages)
            {
                var delivery = group.MapToDelivery();

                var client = new WebHDFSClient(new Uri(@"http://127.0.0.1:50070/"), "Camper");

                using (var memStream = new MemoryStream(SerializationHelper.Serialize(delivery)))
                {
                    var task = client.CreateFile(memStream, string.Format("{0}/{1}_{2}", DirectoryPath, delivery.Vehicle.VehicleId, group.Key));
                    task.Wait();
                }
            }
        }
    }
}
