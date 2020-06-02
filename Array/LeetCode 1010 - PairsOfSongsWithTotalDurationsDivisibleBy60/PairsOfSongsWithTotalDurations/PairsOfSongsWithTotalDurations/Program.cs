//计算每个时间除以60的剩余秒数sec。那么能和当前时间组成整数分钟的时间就是60-sec。将改时间的个数记入结果。注意要特殊处理sec为0的情况。
//将当前sec在seconds中对应的个数加一。
using System;

namespace PairsOfSongsWithTotalDurations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] time = { 30, 20, 150, 100, 40 };
            Console.WriteLine(NumPairsDivisibleBy60(time));
        }
        static int NumPairsDivisibleBy60(int[] time)
        {
            var seconds = new int[60];
            int count = 0;
            foreach (var t in time)
            {
                int sec = t % 60;
                count += sec == 0 ? seconds[sec] : seconds[60 - sec];
                seconds[sec]++;
            }
            return count;
        }
    }
}
