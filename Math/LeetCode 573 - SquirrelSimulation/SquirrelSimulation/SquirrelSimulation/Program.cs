using System;

namespace SquirrelSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 5, width = 5;
            int[] tree = {3, 2}, squirrel = {0, 1};
            int[][] nuts = new[]
            {
                new[] {0, 2},
                new[] {0, 0},
                new[] {2, 2},
            };
            Console.WriteLine(MinDistance(height, width, tree, squirrel, nuts));
        }
        public static int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts)
        {
            int res = 0, dis = int.MinValue;
            foreach (var nut in nuts)
            {
                var temp1 = Distance(nut, squirrel);
                var temp2 = Distance(nut, tree);
                res += 2 * temp2;
                dis = Math.Max(dis, temp2 - temp1);
            }
            return res - dis;
        }

        public static int Distance(int[] p1, int[] p2) => Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);
    }
}
