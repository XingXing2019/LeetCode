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

           long a = 100000, b = 100000;
           Console.WriteLine(a * b);
        }
        static int CountPairs(int[] deliciousness)
        {
            var dict = new Dictionary<int, long>();
            foreach (var num in deliciousness)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                dict[num]++;
            }
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
