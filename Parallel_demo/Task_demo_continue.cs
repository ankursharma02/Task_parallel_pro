using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_demo
{
    class Task_demo_continue
    {
        public static void demo(int i, int j)
        {
            Console.WriteLine("Task " + i + " is begin ");
            // Task.Delay(j);
            Thread.Sleep(j);
            Console.WriteLine("Task " + i + " is end ");
        }
        public static void demo1(int i, int j)
        {
            Console.WriteLine("other Task " + i + " is begin ");
            // Task.Delay(j);
            Thread.Sleep(j);
            Console.WriteLine("other Task " + i + " is end ");
        }
        public static void Main(string[] args)
        {

            Task t1 = Task.Factory.StartNew(() => demo(1, 1000)).ContinueWith((prev)=>demo1(1,2000));
            Task t2 = Task.Factory.StartNew(() => demo(2, 2000));

            Task t3 = Task.Factory.StartNew(() => demo(3, 3000));
            //t1.Start();
            //t2.Start();
            //t3.Start();
            Console.ReadLine();


        }
    }
}
