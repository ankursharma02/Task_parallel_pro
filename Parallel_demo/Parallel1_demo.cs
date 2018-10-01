using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_demo
{
    class Parallel1_demo
    {
        static void HelloConsole()
        {
            Console.WriteLine("Hello Task");
        }

        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(HelloConsole));
            task1.Start();
            Task task2 = new Task(delegate { HelloConsole(); });
            task2.Start();
            Task task3 = new Task(() => HelloConsole());
            task3.Start();
            Console.ReadLine();
        }
    }
}
