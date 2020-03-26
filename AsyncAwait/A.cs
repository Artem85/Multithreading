using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class A
    {
        public static void Test()
        {
            Console.WriteLine("Test A has been started");

            FirstMethodAsync();

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        static async void FirstMethodAsync()
        {
            await Task.Run(() => SecondMethodAsync());
        }

        static async void SecondMethodAsync()
        {
            int a = 8;
            int b = 17;

            await Task.Run(() => Console.WriteLine($"{a} + {b} = {a+b}"));
        }
    }
}
