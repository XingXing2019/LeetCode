using System;

namespace SumInAMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MatrixSum(int[][] nums)
        {
            foreach (var num in nums)
                Array.Sort(num, (a, b) => b - a);
            var res = 0;
            for (int j = 0; j < nums[0].Length; j++)
            {
                var max = 0;
                for (int i = 0; i < nums.Length; i++)
                    max = Math.Max(max, nums[i][j]);
                res += max;;
            }
            return res;
        }
    }
}
