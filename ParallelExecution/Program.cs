using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParallelExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectDir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string folderName = $@"{projectDir}/ParallelExecTest";

            var files = Directory.GetFiles(folderName);

            //Parallel.Foreach
            int totalAndCntForEach = 0;
            Parallel.ForEach<string>(files, (file =>
            {
                int andCount = 0;

                string text = File.ReadAllText(file);
                var andMatches = Regex.Matches(text, "and");
                andCount = andMatches.Count;

                Console.WriteLine($"File {file} contains {andCount} 'and'");
                totalAndCntForEach += andCount;
            }));
            Console.WriteLine($"Total 'and' count is {totalAndCntForEach}");

            //PLINQ
            var processedFiles = files
                                .AsParallel()
                                .Select(t => new
                                {
                                    fileName = t,
                                    andCount = GetAndCount(t)
                                });

            int totalAndCountPLINQ = 0;
            foreach (var processedFile in processedFiles)
            {
                Console.WriteLine($"File {processedFile.fileName} contains {processedFile.andCount} 'and'");
                totalAndCountPLINQ += processedFile.andCount;
            }

            Console.WriteLine($"Total 'and' count is {totalAndCountPLINQ}");
            Console.ReadKey();
        }

        private static int GetAndCount(string file)
        {
            string text = File.ReadAllText(file);
            var andMatches = Regex.Matches(text, "and");
            return andMatches.Count;
        }
    }
}