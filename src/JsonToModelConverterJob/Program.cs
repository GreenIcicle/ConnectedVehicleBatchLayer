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
            var allMessages = new List<Message>();
            
            foreach (var file in Directory.GetFiles(localPath)) 
            {
                var content = File.ReadAllText(file);
                allMessages.AddRange(JsonConvert.DeserializeObject<IEnumerable<Message>>(content));
            }

            var writer = new MapInputFileWriter();
            writer.Write(allMessages);
        }
    }
}
