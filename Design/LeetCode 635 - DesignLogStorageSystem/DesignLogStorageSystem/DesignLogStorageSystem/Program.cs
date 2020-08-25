using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignLogStorageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LogSystem();
            logger.Put(1, "2017:01:01:23:59:59");
            logger.Put(2, "2017:01:02:23:59:59");

            logger.Retrieve("2017:01:01:23:59:59", "2017:01:02:23:59:59", "Month");
        }
    }
    public class LogSystem
    {
        Dictionary<int, long> logs = new Dictionary<int, long>();
        const long pre = 100000000000000;
        public LogSystem()
        {
        }

        public void Put(int id, string timestamp)
        {
            var t = timestamp.Replace(":", "");
            logs.Add(id, pre + long.Parse(t));
        }

        public IList<int> Retrieve(string s, string e, string gra)
        {
            long start = pre + long.Parse(s.Replace(":", ""));
            long end = pre + long.Parse(e.Replace(":", ""));

            long div = 1;
            switch (gra)
            {
                case "Year":
                    div = 10000000000;
                    break;
                case "Month":
                    div = 100000000;
                    break;
                case "Day":
                    div = 1000000;
                    break;
                case "Hour":
                    div = 10000;
                    break;
                case "Minute":
                    div = 100;
                    break;
                case "Second":
                    div = 1;
                    break;
                default:
                    div = 1;
                    break;
            }

            start /= div;
            end /= div;
            return logs.Where(x => x.Value / div >= start && x.Value / div <= end).Select(x => x.Key).ToList();
        }
    }
}
