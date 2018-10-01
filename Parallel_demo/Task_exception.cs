using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_demo
{
    class Task_exception
    {
        static void Main(string[] args)
        {
            //creating the tasks  
            Task task1 = new Task(() =>
            {
                NullReferenceException exception = new NullReferenceException();
                exception.Source = "task1";
                throw exception;
            });

            Task task2 = new Task(() =>
            {
                throw new IndexOutOfRangeException();
            });

            Task task3 = new Task(() =>
            {
                Console.WriteLine("Task 3");
            });

            //starting the tasks  
           
            //waiting for all the tasks to complete              
            try
            {
                task1.Start();
                task2.Start();
                task3.Start();

                Task.WaitAll(task1, task2, task3);
            }
            catch (AggregateException ex)
            {
                //enumerate the exceptions  
                foreach (Exception inner in ex.InnerExceptions)
                {
                    Console.WriteLine("Exception type {0} from {1}", inner.GetType(), inner.Source);
                }
            }

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }
    }
}
