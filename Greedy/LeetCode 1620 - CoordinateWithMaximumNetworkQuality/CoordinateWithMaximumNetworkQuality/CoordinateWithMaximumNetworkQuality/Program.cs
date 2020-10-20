using System;
using System.Linq;

namespace CoordinateWithMaximumNetworkQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] BestCoordinate(int[][] towers, int radius)
        {
            towers = towers.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            var max = 0;
            var res = new int[2];
            foreach (var t1 in towers)
            {
                var quality = 0;
                foreach (var t2 in towers)
                {
                    var d = (t1[0] - t2[0]) * (t1[0] - t2[0]) + (t1[1] - t2[1]) * (t1[1] - t2[1]);
                    if (d <= radius * radius)
                        quality += (int) (t2[2] / (1 + Math.Sqrt(d)));
                }
                if (quality > max)
                {
                    max = quality;
                    res[0] = t1[0];
                    res[1] = t1[1];
                }
            }
            return res;
        }
    }
}
