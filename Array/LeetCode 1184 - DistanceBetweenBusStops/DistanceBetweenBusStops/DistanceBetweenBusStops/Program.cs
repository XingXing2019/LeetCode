//计算起点和终点之间两条路径的距离，返回较小的一个。
//需要注意，start可能大于destination，所有要重新定义起点s为start和destination中较小的值。终点d为start和destination中较大的值。
using System;

namespace DistanceBetweenBusStops
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] distance = { 7, 10, 1, 12, 11, 14, 5, 0 };
            int start = 7;
            int destination = 2;
            Console.WriteLine(DistanceBetweenBusStops(distance, start, destination));
        }
        static int DistanceBetweenBusStops(int[] distance, int start, int destination)
        {
            int s = Math.Min(start, destination);
            int d = Math.Max(start, destination);
            int distance1 = 0, distance2 = 0;
            for (int i = s; i < d; i++)
                distance1 += distance[i];
            for (int i = s - 1; i >= 0; i--)
                distance2 += distance[i];
            for (int i = d; i < distance.Length; i++)
                distance2 += distance[i];
            return Math.Min(distance1, distance2);
        }
    }
}
