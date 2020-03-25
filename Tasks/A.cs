using System;
using System.Threading.Tasks;

namespace Tasks
{
    class A
    {
        public static void Test(int a, int b)
        {
            Console.WriteLine("Test A has been started");

            Task<int> task = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return a + b;
            });

            task.ContinueWith(t => {
                Console.WriteLine($"{a} + {b} = {t.Result}");

                Console.WriteLine("Press Enter to Continue");
            });

            Console.ReadKey();
        }
    }
}
