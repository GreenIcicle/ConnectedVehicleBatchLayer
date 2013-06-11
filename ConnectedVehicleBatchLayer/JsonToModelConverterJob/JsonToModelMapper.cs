using Microsoft.Hadoop.MapReduce;
using Microsoft.Hadoop.MapReduce.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToModelConverterJob
{
    public class JsonToModelMapper : JsonInMapperBase<SensorMessage>
    {
        public override void Map(SensorMessage sensorMessage, MapperContext context)
        {
            //TODO
        }
    }
}
