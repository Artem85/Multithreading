using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Synchronization
{
    public class C
    {
        static ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();

        public static void Test()
        {
            var thread1 = new Thread(Add5Elements)
            {
                Name = "Thread 1"
            };
            var thread2 = new Thread(Add5Elements)
            {
                Name = "Thread 2"
            };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"dict.Count = {dict.Count}");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        private static void Add5Elements()
        {
            for (int i = 0; i < 5; i++)
            {
                int key = Thread.CurrentThread.ManagedThreadId * 100 + i;
                string item = Thread.CurrentThread.Name + $" item {i}";
                dict[key] = item;
                Console.WriteLine($"Add key:{key}, item:{item}");
            }
        }
    }
}
