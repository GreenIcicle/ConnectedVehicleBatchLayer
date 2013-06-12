using Microsoft.Hadoop.MapReduce;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.KmPerVehicle
{
    public class TsvReducer :  ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            var vehileKilometerSensorData = values.Select(v => double.Parse(v)).ToList();
            var totalKilometers = vehileKilometerSensorData.Max() - vehileKilometerSensorData.Min();
            context.EmitKeyValue(key, totalKilometers.ToString(CultureInfo.InvariantCulture));    
        }
    }
}
