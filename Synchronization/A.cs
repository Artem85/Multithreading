using System;
using System.Threading.Tasks;

namespace Synchronization
{
    public class A
    {
        static readonly object locker1 = new object();
        static readonly object locker2 = new object();

        public static void Test()
        {
            Console.WriteLine("Start");

            var task1 = Task.Run(() =>
            {
                lock (locker1)
                {
                    Task.Delay(1000);
                    lock (locker2)
                    {
                        Console.WriteLine("Finish task1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (locker2)
                {
                    Task.Delay(1000);
                    lock (locker1)
                    {
                        Console.WriteLine("Finish task2");
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine("Finish");
        }
    }
}
