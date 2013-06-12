using Microsoft.Hadoop.MapReduce;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.KmPerVehicle
{
    public class Mapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            var delivery = new Delivery();
            double result = 0.0;

            context.Log("MAPPER:::START");
            context.Log(inputLine);
            context.Log("UTF-8: " + Encoding.UTF8.GetBytes(inputLine).Length);
            context.Log("ASCII: " + Encoding.ASCII.GetBytes(inputLine).Length);
            
            
            // Read the incoming string as a Thrift Binary serialized object
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(inputLine));
            using (var transport = new TStreamTransport(inputStream, null))
            {
                delivery.Read(new TBinaryProtocol(transport));
                context.Log("MAPPER:::AFTER_READ");


                // Get the driven kilometers from the vehicle's odometer sensor
                var sensorData = delivery.Vehicle.SensorHistory;
                var minOdo = sensorData.Min(d => d.OdoMeter);
                var maxOdo = sensorData.Max(d => d.OdoMeter);
                result = maxOdo - minOdo;

                context.Log("MAPPER:::BEFORE_STREAM_CLOSE");
            }
            context.Log("MAPPER:::AFTER_STREAM_CLOSE");
                        
            // Emit the vehicle id, and the driven kilometers.
            if (result > 0.1)
            {
                context.EmitKeyValue(delivery.Vehicle.VehicleId, result.ToString(CultureInfo.InvariantCulture));
            }

            context.Log("MAPPER:::END");
        }
    }
}
