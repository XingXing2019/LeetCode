using System;
using System.Linq;

namespace NumberOfWaysToSelectBuildings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "1011100";
            Console.WriteLine(NumberOfWays(s));
        }
        public static long NumberOfWays(string s)
        {
            int[] front = new int[s.Length], after = new int[s.Length];
            int frontZero = 0, frontOne = 0, afterZero = 0, afterOne = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    front[i] = frontOne;
                    frontZero++;
                }
                else
                {
                    front[i] = frontZero;
                    frontOne++;
                }
                if (s[^(i + 1)] == '0')
                {
                    after[^(i + 1)] = afterOne;
                    afterZero++;
                }
                else
                {
                    after[^(i + 1)] = afterZero;
                    afterOne++;
                }
            }
            long res = 0;
            for (int i = 0; i < s.Length; i++)
                res += front[i] * after[i];
            return res;
        }
    }
}
