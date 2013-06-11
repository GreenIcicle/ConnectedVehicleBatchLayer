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

                using(var memStream = new MemoryStream())
                using(var binaryReader = new BinaryReader (memStream))
                {
                    SerializationHelper.Serialize(delivery, memStream);
                    memStream.Position = 0;

                    HdfsFile.WriteAllBytes
                        (
                            string.Format("{0}/{1}_{2}", DirectoryPath, delivery.Vehicle.VehicleId, group.Key), 
                            binaryReader.ReadBytes((int)memStream.Length)
                        );
                }
               
            }
        }
    }
}
