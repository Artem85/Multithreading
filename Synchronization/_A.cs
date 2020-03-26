using System;
using System.Threading;

namespace Synchronization
{
    public class _A
    {
        static int x;

        public static void Test()
        {
            Console.WriteLine("Test _A has been started");

            for (int i = 0; i < 5; i++)
            {
                var thread1 = new Thread(() => XIncrease(1));
                var thread2 = new Thread(() => XIncrease(2));

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();
            }
            Console.WriteLine($"x = {x}");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        static void XIncrease (int increment)
        {
            Interlocked.Add(ref x, increment);
            //x += increment;
        }
    }

}
