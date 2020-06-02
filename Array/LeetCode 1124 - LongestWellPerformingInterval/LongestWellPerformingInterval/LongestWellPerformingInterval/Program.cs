//用dayDiff记录当前tiring与non-tiring的差值。并用一个字典记录dayDiff为负的时候所对应的日期。
//遍历数组，如果当前hour大于8则day加一，否则减一。
//如果dayDiff大于零则将res更新为i + 1。因为从第0天到当前日tiring大于non-tiring。
//如果dayDiff小于零，则在字典不从在dayDiff的情况下将当前日期加进去(之后如果出现相同的dayDiff，无需更新字典，因为后出现的i肯定大于之前的i，所以不用考虑)。
//如果字典中存在dayDiff-1，则证明之前有一天和当前日期能组成符合条件的子串，则判断并决定是否更新res。
using System;
using System.Collections.Generic;

namespace LongestWellPerformingInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hours = {0, 9, 6, 9, 9, 6, 9};
            Console.WriteLine(LongestWPI1(hours));
        }

        static int LongestWPI1(int[] hours)
        {
            var record = new Dictionary<int, int>();
            int dayDiff = 0;
            int res = 0;
            for (int i = 0; i < hours.Length; i++)
            {
                dayDiff += hours[i] > 8 ? 1 : -1;
                if (dayDiff > 0)
                    res = i + 1;
                else
                {
                    if (!record.ContainsKey(dayDiff))
                        record[dayDiff] = i;
                    if (record.ContainsKey(dayDiff - 1))
                        res = Math.Max(res, i - record[dayDiff - 1]);
                }
            }
            return res;
        }
        static int LongestWPI2(int[] hours)
        {
            var tiring = new int[hours.Length + 1];
            var nonTiring = new int[hours.Length + 1];
            for (int i = 0; i < hours.Length; i++)
            {
                if (hours[i] > 8)
                {
                    tiring[i + 1] = tiring[i] + 1;
                    nonTiring[i + 1] = nonTiring[i];
                }
                else
                {
                    tiring[i + 1] = tiring[i];
                    nonTiring[i + 1] = nonTiring[i] + 1;
                }
            }
            int res = 0;
            for (int i = tiring.Length - 1; i >= 0; i--)
            {
                int day = 0;
                for (int j = 0; j < i; j++)
                {
                    if (tiring[i] - tiring[j] > nonTiring[i] - nonTiring[j])
                    {
                        day = i - j;
                        break;
                    }
                }
                res = Math.Max(res, day);
            }
            return res;
        }
    }
}
