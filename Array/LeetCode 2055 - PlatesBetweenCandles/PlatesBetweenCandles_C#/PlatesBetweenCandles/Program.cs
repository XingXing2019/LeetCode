using System;

namespace PlatesBetweenCandles
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "***";
            int[][] queries = new[]
            {
                new[] {2, 2}
            };
            Console.WriteLine(PlatesBetweenCandles(s, queries));
        }

        public static int[] PlatesBetweenCandles(string s, int[][] queries)
        {
            int[] plateCount = new int[s.Length], leftCandle = new int[s.Length], rightCandle = new int[s.Length];
            var res = new int[queries.Length];
            int left = -1, right = -1, plates = 0;
            for (int i = 0; i < s.Length; i++)
            {
                plateCount[i] = plates;
                if (s[i] == '*')
                    plates++;
                else
                    left = i;
                if (s[^(i + 1)] == '|')
                    right = s.Length - i - 1;
                leftCandle[i] = left;
                rightCandle[^(i + 1)] = right;
            }
            for (int i = 0; i < queries.Length; i++)
            {
                left = Math.Max(queries[i][0], rightCandle[queries[i][0]]);
                right = Math.Max(0, Math.Min(queries[i][1], leftCandle[queries[i][1]]));
                res[i] = Math.Max(0, plateCount[right] - plateCount[left]);
            }
            return res;
        }
    }
}
