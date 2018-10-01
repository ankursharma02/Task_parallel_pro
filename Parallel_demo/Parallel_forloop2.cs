using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace Parallel_demo
{
    class Parallel_forloop2
    {
        public static void Main(String[] args)
        {
            long totalSize = 0;
            string path = "E:\\test\\src";
            

            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory does not exist.");
                Console.ReadLine();
                return;
            }

            String[] files = Directory.GetFiles(path);
            Parallel.For(0, files.Length,
                         index => {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory "+ path);
            Console.WriteLine(files.Length+" files, " + totalSize+" bytes");
            Console.ReadLine();
        }


    }
}
