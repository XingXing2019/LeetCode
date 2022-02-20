using System;
using System.Linq;
using System.Text;

namespace ConstructStringWithRepeatLimit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "cczazc";
            var repeatLimit = 2;
            Console.WriteLine(RepeatLimitedString(s, repeatLimit));
        }
        public static string RepeatLimitedString(string s, int repeatLimit)
        {
            var record = s.GroupBy(x => x).OrderByDescending(x => x.Key).Select(x => new[] { x.Key - 'a', x.Count() }).ToArray();
            var res = new StringBuilder();
            var p1 = 0;
            while (p1 < record.Length)
            {
                if (record[p1][1] >= repeatLimit)
                {
                    var count = res.Length != 0 && res[^1] - 'a' == record[p1][0] ? repeatLimit - 1 : repeatLimit;
                    res.Append(new string((char)(record[p1][0] + 'a'), count));
                    record[p1][1] -= count;
                    var p2 = p1 + 1;
                    while (p2 < record.Length && record[p2][1] == 0)
                        p2++;
                    if (p2 == record.Length) return res.ToString();
                    res.Append((char)(record[p2][0] + 'a'));
                    record[p2][1]--;
                }
                else
                {
                    res.Append(new string((char)(record[p1][0] + 'a'), record[p1][1]));
                    p1++;
                }
            }
            return res.ToString();
        }
    }
}
