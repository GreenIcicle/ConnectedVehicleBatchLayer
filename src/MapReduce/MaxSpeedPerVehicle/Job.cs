using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.MaxSpeedPerVehicle
{
    public class Job : HadoopJob<Mapper, Reducer>
    {

        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            throw new NotImplementedException();
        }
    }
}
