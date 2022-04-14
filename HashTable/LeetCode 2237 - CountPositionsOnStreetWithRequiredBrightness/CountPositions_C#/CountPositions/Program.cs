using System;

namespace CountPositions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MeetRequirement(int n, int[][] lights, int[] requirement)
        {
            var record = new int[n + 1];
            foreach (var light in lights)
            {
                var start = Math.Max(0, light[0] - light[1]);
                var end = Math.Min(n, light[0] + light[1] + 1);
                record[start]++;
                record[end]--;
            }
            int count = 0, res = 0;
            for (int i = 0; i < n; i++)
            {
                count += record[i];
                if (count < requirement[i]) continue;
                res++;
            }
            return res;
        }
    }
}
