//暴力遍历即可，但需要注意，如果x或y等于1的时候会造成死循环，要终止遍历。
using System;
using System.Collections.Generic;

namespace PowerfulIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 1;
            int bound = 10;
            Console.WriteLine(PowerfulIntegers(x, y, bound));
        }
        static IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            var dict = new Dictionary<double, int>();
            int i = 0, j = 0;
            for (; Math.Pow(x, i) + Math.Pow(y, j) <= bound; i++)
            {
                for (; Math.Pow(x, i) + Math.Pow(y, j) <= bound; j++)
                {
                    if (!dict.ContainsKey(Math.Pow(x, i) + Math.Pow(y, j)))
                        dict[Math.Pow(x, i) + Math.Pow(y, j)] = 1;
                    if (y == 1)
                        break;
                }
                j = 0;
                if (x == 1)
                    break;
            }
            var res = new List<int>();
            foreach (var kv in dict)
                res.Add((int)kv.Key);
            return res;
        }
    }
}
