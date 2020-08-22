using System;
using System.Linq;

namespace RandomPointInNonOverlappingRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Solution
        {
            private readonly int[][] _rects;
            private readonly int[] _weightSum;
            private readonly Random _rnd = new Random();

            public Solution(int[][] rects)
            {
                _rects = rects;
                _weightSum = new int[rects.Length];
                int max = 0;

                checked
                {
                    for (int i = 0; i < rects.Length; i++)
                    {
                        int square = ((rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1]) + 1);
                        max += square;
                        _weightSum[i] = max;
                    }
                }
            }

            private int PickRndRect()
            {
                int weight = _rnd.Next(0, _weightSum.Last()) + 1;
                int res = Array.BinarySearch(_weightSum, weight);
                return res >= 0 ? res : -res - 1;
            }

            public int[] Pick()
            {
                var rectIdx = PickRndRect();
                var rndX = _rnd.Next(_rects[rectIdx][0], _rects[rectIdx][2] + 1);
                var rndY = _rnd.Next(_rects[rectIdx][1], _rects[rectIdx][3] + 1);
                return new int[] { rndX, rndY };
            }
        }

    }
}
