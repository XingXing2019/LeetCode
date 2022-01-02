
using System;
using System.Linq;

namespace NumberOfLaserBeamsInABank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfBeams(string[] bank)
        {
            int res = 0, last = bank[0].Count(x => x == '1');
            for (int i = 1; i < bank.Length; i++)
            {
                var cur = bank[i].Count(x => x == '1');
                if (cur == 0) continue;
                res += last * cur;
                last = cur;
            }
            return res;
        }
    }
}
