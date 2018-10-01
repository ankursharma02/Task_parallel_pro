using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_demo
{
    class TaskExcepetion2
    {
        public static void Main()
        {
         //   var task1 = Task.Run(() => { throw new CustomException("This exception is expected!"); });

            try
            {
                var task1 = Task.Run(() => { throw new CustomException("This exception is expected!"); });

                task1.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle the custom exception.
                  //  if (e is CustomException)
                  //  {
                        Console.WriteLine(e.Message);
                   // }
                    // Rethrow any other exception.
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
        }
    }

    public class CustomException : Exception
    {
        public CustomException(String message) : base(message)
        { }
    }
    // The example displays the following output:
    //        This exception is expected!

}
