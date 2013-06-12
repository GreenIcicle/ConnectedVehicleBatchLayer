using Microsoft.Hadoop.MapReduce;
using Microsoft.Hadoop.WebHDFS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToModelConverterJob
{
    class Program
    {
        static void Main(string[] args)
        {

            Process(args[0]);
            //var hadoop = Hadoop.Connect();
            //var result = hadoop.MapReduceJob.ExecuteJob<ConverterJob>();
            //Console.ReadLine();
        }

        private static void Process(string localPath)
        {
            foreach (var file in Directory.GetFiles(localPath)) 
            {
                var content = File.ReadAllText(file);
                var messages = JsonConvert.DeserializeObject<IEnumerable<Message>>(content);
                var mapper = new JsonToModelMapper();
                mapper.Map(messages);
            }
        }
    }
}
