using System;
using System.Collections.Generic;

namespace FallingSquares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] positions = new int[][]
            {
                new[] { 4, 6 },
                new[] { 4, 2 },
                new[] { 4, 3 },
            };
            Console.WriteLine(FallingSquares(positions));
        }

        public static IList<int> FallingSquares(int[][] positions)
        {
            var res = new List<int>();
            var boxes = new List<int[]>();
            var max = 0;
            foreach (var position in positions)
            {
                var baseHeight = 0;
                foreach (var box in boxes)
                {
                    if (box[1] <= position[0] || box[0] >= position[0] + position[1]) continue;
                    baseHeight = Math.Max(baseHeight, box[2]);
                }
                boxes.Add(new []{position[0], position[0] + position[1], baseHeight + position[1]});
                max = Math.Max(max, baseHeight + position[1]);
                res.Add(max);
            }
            return res;
        }
    }
}
