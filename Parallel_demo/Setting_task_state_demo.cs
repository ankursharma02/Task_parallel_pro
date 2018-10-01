using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_demo
{
    class Setting_task_state_demo
    {
        static void HelloConsole(object msg)
        {
            Console.WriteLine("Hello Task "+msg);
        }

        static void Main(string[] args)
        {
            Task task1 = new Task(new Action<object>(HelloConsole),"Task 1");
            task1.Start();
            Task task2 = new Task(delegate (object obj) { HelloConsole(obj); },"Task2");
            task2.Start();
            Task task3 = new Task((obj) => HelloConsole(obj),"Task 3");
            task3.Start();

            Task<int> task4 = new Task<int>(() =>
            {
                int result = 1;

                for (int i = 1; i < 5; i++)
                    result *= i;

                return result;
            });

            //starting the task  
            task4.Start();

            //waiting for result - printing to the console  
            Console.WriteLine("Task result: "+ task4.Result);

            Console.WriteLine("Main method complete. ");       

                   Console.ReadLine();
        }
    }
}



