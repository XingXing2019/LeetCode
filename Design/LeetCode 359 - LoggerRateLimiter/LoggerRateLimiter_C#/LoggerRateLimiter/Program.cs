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
        private Dictionary<int, HashSet<string>> logger;
        public Logger()
        {
            logger = new Dictionary<int, HashSet<string>>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if(!logger.ContainsKey(timestamp))
                logger[timestamp] = new HashSet<string>();
            for (int i = 0; i < 10; i++)
            {
                int time = timestamp - i;
                if (logger.ContainsKey(time) && logger[time].Contains(message))
                    return false;
            }
            logger[timestamp].Add(message);
            return true;
        }
    }
}
