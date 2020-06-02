using System;
using System.Linq;

namespace MaximumScoreAfterSplittingAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxScore(string s)
        {
            int zeros = 0;
            int ones = s.Count(c => c == '1');
            var record = new int[s.Length - 1];
            int res = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '0')
                    zeros++;
                else
                    ones--;
                record[i] = zeros + ones;
                res = Math.Max(res, record[i]);
            }
            return res;
        }
    }
}
