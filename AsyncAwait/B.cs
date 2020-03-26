using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class B
    {
        public static async void Test()
        {
            Console.WriteLine("Test B has been started");

            try
            {
                await VoidMethodAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
            }

            Console.WriteLine("Press Enter to Continue");
            Console.ReadKey();
        }

        static async Task VoidMethodAsync()
        {
            await Task.Run(() =>
            {
                throw new Exception("Intentional exception");
            });
        }
    }
}
