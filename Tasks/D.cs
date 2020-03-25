using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class D
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Test D has been started");

            try
            {
                var task = Task.Run(() =>
                {
                    throw new Exception("Intentional exception");
                });

                Console.WriteLine($"Some work in main thread. Thread id is {Thread.CurrentThread.ManagedThreadId}");

                while (!task.IsCompleted) { }

                if (task.IsFaulted)
                {
                    throw task.Exception;
                }
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
