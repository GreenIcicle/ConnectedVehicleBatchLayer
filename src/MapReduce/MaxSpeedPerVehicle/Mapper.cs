using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.MaxSpeedPerVehicle
{
    public class Mapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            var delivery = SerializationHelper.Deserialize<Delivery>(inputLine);

            //TODO
        }
    }
}
