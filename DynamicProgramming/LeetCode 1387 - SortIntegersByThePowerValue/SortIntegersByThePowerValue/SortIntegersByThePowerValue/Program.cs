using System;
using System.Collections.Generic;
using System.Linq;

namespace SortIntegersByThePowerValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int lo = 10, hi = 20, k = 5;
            Console.WriteLine(GetKth(lo, hi, k));

           
        }
        static int GetKth(int lo, int hi, int k)
        {
            var dict = new Dictionary<int, int[]>();
            for (int num = lo; num <= hi; num++)
            {
                if (dict.ContainsKey(num))
                    continue;
                dict[num] = new[] { num, 0 };
                int step = 0;
                int temp = num;
                int count = 0;
                while (temp != 1)
                {
                    if (temp % 2 == 0)
                        temp /= 2;
                    else
                        temp = temp * 3 + 1;
                    count++;
                    step--;
                    if (!dict.ContainsKey(temp) && temp <= hi && temp >= lo)
                        dict[temp] = new[] { num, step };
                }
                dict[num][1] = count;
            }
            foreach (var kv in dict)
                if (kv.Value[0] != kv.Key)
                    kv.Value[1] += dict[kv.Value[0]][1];
            var orderedNums = dict.OrderBy(x => x.Value[1]).ThenBy(x => x.Key).Select(x => x.Key).ToArray();
            return orderedNums[k - 1];
        }

        static int Count(int num)
        {
            int count = 0;
            while (num != 1)
            {
                if (num % 2 == 0)
                    num /= 2;
                else
                    num = num * 3 + 1;
                count++;
            }
            return count;
        }
    }

    
}
