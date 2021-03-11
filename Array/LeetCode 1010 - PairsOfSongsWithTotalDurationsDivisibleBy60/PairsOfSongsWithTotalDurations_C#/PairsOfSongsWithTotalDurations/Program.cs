//计算每个时间除以60的剩余秒数sec。那么能和当前时间组成整数分钟的时间就是60-sec。将改时间的个数记入结果。注意要特殊处理sec为0的情况。
//将当前sec在seconds中对应的个数加一。
using System;
using System.Collections.Generic;

namespace PairsOfSongsWithTotalDurations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] time = { 30, 20, 150, 100, 40 };
            Console.WriteLine(NumPairsDivisibleBy60_Array(time));
        }
        static int NumPairsDivisibleBy60_Array(int[] time)
        {
            var seconds = new int[60];
            int res = 0;
            foreach (var t in time)
            {
                res += t % 60 == 0 ? seconds[t % 60] : seconds[60 - t % 60];
                seconds[t % 60]++;
            }
            return res;
        }
        static int NumPairsDivisibleBy60_Dictionary(int[] time)
        {
            var res = 0;
            var dict = new Dictionary<int, int>();
            foreach (var t in time)
            {
                if (dict.ContainsKey(60 - t % 60))
                    res += dict[60 - t % 60];
                if (t % 60 == 0 && dict.ContainsKey(t % 60))
                    res += dict[t % 60];
                if (!dict.ContainsKey(t % 60))
                    dict[t % 60] = 0;
                dict[t % 60]++;
            }
            return res;
        }
    }
}
