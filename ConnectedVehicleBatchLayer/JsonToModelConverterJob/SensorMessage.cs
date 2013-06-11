using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToModelConverterJob
{
    public class SensorMessage
    {
        [JsonProperty(PropertyName = "type")]
        public string Type{get; set;}

        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }

        [JsonProperty(PropertyName = "deliveryId")]
        public int DeliveryId { get; set; }

        [JsonProperty(PropertyName = "vid")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "coordinate")]
        public Position Position { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty(PropertyName = "sequence")]
        public int Sequence { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "fuel")]
        public double Fuel { get; set; }

        [JsonProperty(PropertyName = "kilometer")]
        public double Kilometer { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }
    }
}
