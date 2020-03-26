using System;
using System.Collections.Generic;
using System.Threading;

namespace Synchronization
{
    public class E
    {
        static Semaphore semaphore = new Semaphore(2, 2);

        public static void Test()
        {
            var thread1 = new Thread(WriteToConsole);
            var thread2 = new Thread(WriteToConsole);
            var thread3 = new Thread(WriteToConsole);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadKey();
        }

        static void WriteToConsole()
        {
            semaphore.WaitOne();

            Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            semaphore.Release();
        }
    }
}
