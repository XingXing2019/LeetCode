
using System;
using System.Linq;

namespace TwoBestNonOverlappingEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] events =
            {
                new[] { 1, 3, 2 },
                new[] { 4, 5, 2 },
                new[] { 1, 5, 5 },
            };
            Console.WriteLine(MaxTwoEvents(events));
        }

        public static int MaxTwoEvents(int[][] events)
        {
            events = events.OrderBy(x => x[0]).ToArray();
            var maxValue = new int[events.Length];
            int max = 0, res = 0;
            for (int i = events.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, events[i][2]);
                maxValue[i] = max;
            }
            for (int i = 0; i < events.Length; i++)
            {
                int li = i, hi = events.Length - 1;
                while (li <= hi)
                {
                    var mid = li + (hi - li) / 2;
                    if (events[i][1] >= events[mid][0])
                        li = mid + 1;
                    else
                        hi = mid - 1;
                }
                res = Math.Max(res, events[i][2] + (li < events.Length ? maxValue[li] : 0));
            }
            return res;
        }
    }
}
