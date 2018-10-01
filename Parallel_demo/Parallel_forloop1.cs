using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Parallel_demo
{
    class Parallel_forloop1
    {

        public static void Main(String[] args)
        {
            long totalSize = 0;

           
            if (args.Length <= 0)
            {
                Console.WriteLine("There are no command line arguments.");
                Console.ReadLine();
                return;
            }
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(args[0]);
            Parallel.For(0, files.Length,
                         index => {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory '{0}':", args[0]);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
            Console.ReadLine();
        }

    }
}
