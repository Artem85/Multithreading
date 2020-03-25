using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class F
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Test F has been started");

            var tasks = new List<Task<int>>();

            for (int i = 0; i < 10; i++)
            {
                int index = i;
                var task = Task<int>.Run(() =>
                {
                    Thread.Sleep(1000 + index * 200);
                    //Console.WriteLine($"Result: {index}; Current ThreadId: {Thread.CurrentThread.ManagedThreadId}");

                    return index;
                });

                tasks.Add(task);
            };

            //Task fTask = Task.WhenAny(tasks.ToArray());
            //fTask.Wait();

            int completedTask = Task.WaitAny(tasks.ToArray());
            Console.WriteLine($"Task# {completedTask} has been completed.");

            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.Id}; Status: {task.Status}");
            }

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }
    }
}
