using System;
using System.Collections.Generic;
using System.Linq;

namespace CountGoodMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] deliciousness = { 32 };
            Console.WriteLine(CountPairs(deliciousness));
        }
        static int CountPairs(int[] deliciousness)
        {
            var dict = deliciousness.GroupBy(x => x).ToDictionary(x => x.Key, x => Convert.ToInt64(x.Count()));
            long res = 0; 
            int mod = 1_000_000_000 + 7;
            foreach (var kv in dict)
            {
                int pow = 1;
                for (int i = 0; i <= 21; i++)
                {
                    if (dict.ContainsKey(pow - kv.Key))
                        res += kv.Value * (pow - kv.Key == kv.Key ? kv.Value - 1 : dict[pow - kv.Key]);
                    pow *= 2;
                }
            }
            return (int) (res / 2 % mod);
        }
    }
}
