using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectreConsoleDemo
{
    internal class ParallelUse
    {
        public static void Use()
        {
            List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };
            Parallel.ForEach(names, name => {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"Hello, {name}!");
            });


            //Parallel.Invoke(DoSomeWork);
        }

        private static void DoSomeWork()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
