using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.KmPerVehicle
{
    /// <summary>
    /// A version of the mapper that does not use Thrift (which does not
    /// work due to the default FileFormat of the Hadoop Streaming API),
    /// but uses a dumb tsv file.
    /// </summary>
    public class TsvMapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            // The odometer is on index 2
            var parts = inputLine.Split('\t');
            var id = parts[0];
            var kilometers = parts[2];

            context.EmitKeyValue(id, kilometers);
        }
    }
}