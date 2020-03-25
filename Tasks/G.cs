using System;
using System.Threading.Tasks;

namespace Tasks
{
    class G
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Test G has been started");

            var parrentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task is executing");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child task is executing");
                    Task.Delay(5000).Wait();
                    Console.WriteLine("Child task has been completed");
                }
                , TaskCreationOptions.AttachedToParent);

                Task.Delay(1000).Wait();
            });

            parrentTask.Wait();
            Console.WriteLine("Parent task has been completed");

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }
    }
}
