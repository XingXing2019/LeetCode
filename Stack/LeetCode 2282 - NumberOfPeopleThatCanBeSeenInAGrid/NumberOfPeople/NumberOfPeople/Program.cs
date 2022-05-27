using System;
using System.Collections.Generic;

namespace NumberOfPeople
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] heights = new[]
            {
                new[] { 5, 4, 4, 3 }
            };
            Console.WriteLine(SeePeople(heights));
        }

        public static int[][] SeePeople(int[][] heights)
        {
            int m = heights.Length, n = heights[0].Length;
            var res = new int[m][];
            for (int i = 0; i < m; i++)
                res[i] = Count(heights[i]);
            for (int j = 0; j < n; j++)
            {
                var temp = new int[m];
                for (int i = 0; i < m; i++)
                    temp[i] = heights[i][j];
                var seen = Count(temp);
                for (int i = 0; i < m; i++)
                    res[i][j] += seen[i];
            }
            return res;
        }

        public static int[] Count(int[] heights)
        {
            var res = new int[heights.Length];
            var stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                var cur = heights[i];
                while (stack.Count != 0 && heights[stack.Peek()] < cur)
                {
                    var person = stack.Pop();
                    res[person]++;
                }
                if (stack.Count != 0) 
                    res[stack.Peek()]++;
                if (stack.Count != 0 && heights[stack.Peek()] == cur)
                    stack.Pop();
                stack.Push(i);
            }
            return res;
        }
    }
}
