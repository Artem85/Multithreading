using System;
using System.Collections.Generic;
using System.Threading;

namespace Synchronization
{
    public class B
    {
        static List<int> col = new List<int>();
        static object locker = new object();

        public static void Test()
        {
            var thread1 = new Thread(Add5Elements);
            var thread2 = new Thread(Add5Elements);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"col.Count = {col.Count}");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        private static void Add5Elements()
        {
            bool asquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref asquiredLock);

                for (int i = 0; i < 5; i++)
                {
                    int item = Thread.CurrentThread.ManagedThreadId + i;
                    col.Add(item);
                    Console.WriteLine($"Add item {item}");
                }
            }
            finally
            {
                if (asquiredLock)
                    Monitor.Exit(locker);
            }
        }
    }
}
