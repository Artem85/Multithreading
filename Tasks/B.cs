using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class B
    {
        public static void Test(int a, int b)
        {
            Console.WriteLine();
            Console.WriteLine("Test B has been started");

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            
            Task<int> task = new Task<int>(() =>
            {
                token.ThrowIfCancellationRequested();

                Task.Delay(1000).Wait();

                return a + b;
            }, token);

            cts.Cancel();

            try
            {
                task.Start();
            }
            catch { }

            Console.WriteLine($"Current task status is {task.Status}");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }
    }
}
