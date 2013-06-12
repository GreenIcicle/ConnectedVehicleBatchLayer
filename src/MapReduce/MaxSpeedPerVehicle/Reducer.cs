using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.MaxSpeedPerVehicle
{
    public class Reducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
