//在当前时间点与其前一时间点之间的每个时间间隔中，中毒的时间为duration和当前时间间隔中较小的值。
//创建totalTime记录结果。从第二个元素开始遍历数组，将每个时间间隔中毒的时间加入totalTime。遍历结束后再令totalTime加一次duration，代表在最后一个时间点中毒的时间。
using System;

namespace TeemoAttacking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries.Length == 0)
                return 0;
            int totalTime = 0;
            for (int i = 1; i < timeSeries.Length; i++)
                totalTime += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);
            totalTime += duration;
            return totalTime;
        }
    }
}
