using System;
using System.Collections.Generic;

namespace LoggerRateLimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            Console.WriteLine(logger.ShouldPrintMessage(2, "bar"));
            Console.WriteLine(logger.ShouldPrintMessage(3, "foo"));
            Console.WriteLine(logger.ShouldPrintMessage(8, "bar"));
            Console.WriteLine(logger.ShouldPrintMessage(10, "foo"));
            Console.WriteLine(logger.ShouldPrintMessage(11, "foo"));
        }
    }
    public class Logger
    {
        private List<HashSet<string>> logger;
        public Logger()
        {
            logger = new List<HashSet<string>>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (timestamp > logger.Count)
            {
                int count = logger.Count;
                for (int i = 0; i < timestamp - count; i++)
                    logger.Add(new HashSet<string>());
            }
            for (int i = timestamp - 1; i >= 0 && i >= timestamp - 10; i--)
            {
                if (logger[i].Contains(message))
                    return false;
            }
            logger[timestamp - 1].Add(message);
            return true;
        }
    }
}
