using Microsoft.Hadoop.MapReduce;
using System;
namespace Zuehlke.Camp2013.ConnectedVehicles.MapReduce
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Run Map/Reduce jobs
            var hadoop = Hadoop.Connect();

            Console.WriteLine("Running KmPerVehicle");
            var result = hadoop.MapReduceJob.ExecuteJob<KmPerVehicle.Job>();

            // Wait for the user to quit the program
            Console.WriteLine("Done. Press Enter to quit");
            Console.ReadLine();
        }
    }
}
