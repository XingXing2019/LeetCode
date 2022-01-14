using System;
using System.Linq;

namespace PourWaterBetweenBuckets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] buckets = { 2, 4, 6 };
            int loss = 50;
            Console.WriteLine(EqualizeWater(buckets, loss));
        }

        public static double EqualizeWater(int[] buckets, int loss)
        {
            double li = buckets.Min(), hi = buckets.Max();
            while (Math.Abs(li - hi) > 0.00001)
            {
                var mid = li + (hi - li) / 2;
                double waterIn = 0, waterOut = 0;
                foreach (var bucket in buckets)
                {
                    if (bucket >= mid)
                        waterOut += bucket - mid;
                    else
                        waterIn += (mid - bucket) / (1 - (double)loss / 100);
                }
                if (waterIn == waterOut) return mid;
                if (waterIn > waterOut) hi = mid;
                else li = mid;
            }
            return li;
        }
    }
}
