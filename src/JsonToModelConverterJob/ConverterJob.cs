using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToModelConverterJob
{
    public class ConverterJob : HadoopJob<JsonToModelMapper>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            var config = new HadoopJobConfiguration();
            config.InputPath = "input/rawdata";
            config.OutputFolder = "output/data";
            return config;
        }
    }
}
