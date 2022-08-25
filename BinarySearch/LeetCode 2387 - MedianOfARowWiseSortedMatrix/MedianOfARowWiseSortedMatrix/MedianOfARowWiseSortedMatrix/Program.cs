using System;
using System.Linq;

namespace MedianOfARowWiseSortedMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new int[] { 1, 1, 3, 3, 4 }
            };
            Console.WriteLine(MatrixMedian(grid));
        }

        public static int MatrixMedian(int[][] grid)
        {
            int li = 1, hi = grid.Max(x => x[^1]);
            int m = grid.Length, n = grid[0].Length;
            var target = m * n / 2;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var count = grid.Sum(x => BinarySearch(x, mid));
                if (count > target)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }

        private static int BinarySearch(int[] row, int target)
        {
            int li = 0, hi = row.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (row[mid] >= target)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
