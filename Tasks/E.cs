using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class E
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Test E has been started");

            var tasks = new List<Task<int>>();

            for (int i = 0; i < 10; i++)
            {
                int index = i;
                var task = Task<int>.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Result: {index}; Current ThreadId: {Thread.CurrentThread.ManagedThreadId}");

                    return index;
                });

                tasks.Add(task);
            };

            //Task fTask = Task.WhenAll(tasks.ToArray());
            //fTask.Wait();

            Task.WaitAll(tasks.ToArray());

            foreach (var task in tasks)
            {
                Console.WriteLine($"Task result: {task.Result}");
            }

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }
    }
}
