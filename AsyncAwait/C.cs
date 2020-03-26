using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class C
    {
        public static async void Test()
        {
            Console.WriteLine("Test C has been started");

            int a = 8;
            int b = 17;

            int c = SumAsync(a, b).GetAwaiter().GetResult();
            Console.WriteLine($"{a} + {b} = {c}");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        static async Task<int> SumAsync(int a, int b)
        {
            return await Task.Run(() => a + b);
        }
    }
}
