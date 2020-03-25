using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class C
    {
        public static void Test(int a, int b)
        {
            Console.WriteLine();
            Console.WriteLine("Test C has been started");

            var task = Task<int>.Run(() =>
            {
                Task.Delay(1000).Wait();
                throw new Exception("Intentional exception");

                return a + b;
            });

            try
            {
                Console.WriteLine($"{a} + {b} = {task.Result}");
            }
            catch(AggregateException aEx)
            {
                foreach (var ex in aEx.InnerExceptions)
                {
                    Console.WriteLine($"Task exception is: {ex.Message}");
                }
            }

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }
    }
}
