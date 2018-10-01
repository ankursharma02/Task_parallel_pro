using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_demo
{
   
    class Parallel_foreachdemo
    {
        public static void demo(string s)
        {

            Console.WriteLine(s);
        }
        public static void Main(string[] args)
        {
            string[] s1 = {"hello demo","hello again ","new demo" }; 
            Parallel.ForEach(s1,i => demo(i));
            Console.ReadLine();
        }
    }
}
