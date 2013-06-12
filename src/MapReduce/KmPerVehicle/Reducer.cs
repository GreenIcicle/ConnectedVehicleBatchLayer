using Microsoft.Hadoop.MapReduce;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.KmPerVehicle
{
    public class Reducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            // Key is the vehicle ID, values are double values for driven kilometers
            // We need to add up the kilometers.
            var totalDriven = values.Select(v => double.Parse(v)).Sum();

            context.EmitKeyValue(key, totalDriven.ToString(CultureInfo.InvariantCulture));
        }
    }
}
