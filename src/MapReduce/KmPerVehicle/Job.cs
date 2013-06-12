using Microsoft.Hadoop.MapReduce;

namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce.KmPerVehicle
{
    public class Job : HadoopJob<TsvMapper, TsvReducer>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            HadoopJobConfiguration config = new HadoopJobConfiguration();
            
            config.InputPath = "Deliveries-tsv";
            config.OutputFolder = "output/kmPerVehicle";
            return config;
        }
    }
}
