using System;

namespace CrawlerLogFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] logs = {"./", "../", "./"};
            Console.WriteLine(MinOperations(logs));
        }
        static int MinOperations(string[] logs)
        {
            var pos = 0;
            foreach (var log in logs)
            {
                if (log == "../")
                    pos = Math.Max(0, pos - 1);
                else if (log == "./")
                    pos += 0;
                else 
                    pos += 1;
            }
            return pos;
        }
    }
}
