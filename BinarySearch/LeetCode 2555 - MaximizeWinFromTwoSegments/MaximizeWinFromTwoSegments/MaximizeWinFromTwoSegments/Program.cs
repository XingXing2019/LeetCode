using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximizeWinFromTwoSegments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prizePositions = { 1, 1, 2, 2, 3, 3, 5, 6, 6, 6, 6 };
            var k = 2;
            Console.WriteLine(MaximizeWin(prizePositions, k));
        }

        public static int MaximizeWin(int[] prizePositions, int k)
        {
            int res = 0, max = 0;
            var nextLarge = new Dictionary<int, int>();
            var rightMax = new Dictionary<int, int>();
            var prizes = new Dictionary<int, int>();
            var freq = prizePositions.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            for (int i = prizePositions.Length - 1; i >= 0; i--)
            {
                if (prizes.ContainsKey(prizePositions[i])) continue;
                var target = prizePositions[i] + k;
                var index = BinarySearch(prizePositions, target);
                prizes[prizePositions[i]] = index - i - 1 + freq[prizePositions[i]];
                nextLarge[prizePositions[i]] = index == prizePositions.Length ? target : prizePositions[index];
            }
            foreach (var prize in prizes.Keys)
            {
                max = Math.Max(max, prizes[prize]);
                rightMax[prize] = max;
            }
            foreach (var prize in prizes.Keys)
            {
                var next = nextLarge[prize];
                var p1 = prizes[prize];
                var p2 = rightMax.GetValueOrDefault(next, 0);
                if (prize + k == next)
                    p2 -= freq.GetValueOrDefault(next, 0);
                res = Math.Max(res, p1 + p2);
            }
            return res;
        }

        private static int BinarySearch(int[] prizePositions, int target)
        {
            int li = 0, hi = prizePositions.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (prizePositions[mid] <= target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }
    }
}
