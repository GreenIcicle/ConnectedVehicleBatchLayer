using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonInputFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveLineBreaks(args[0], args[1]);
        }

        private static void RemoveLineBreaks(string source, string destination)
        {
            Parallel.ForEach(Directory.GetFiles(source, "*.bz2"), file =>
            {
                using(var fileStream = new FileStream(file, FileMode.Open))
                using (var bz2Stream = new BZip2InputStream(fileStream))
                using(var reader = new StreamReader(bz2Stream))
                {
                    var content = reader.ReadToEnd().Replace(Environment.NewLine, string.Empty);
                    File.WriteAllText(Path.Combine(destination, Path.GetFileNameWithoutExtension(file)), content);
                }
            });
        }
    }
}
