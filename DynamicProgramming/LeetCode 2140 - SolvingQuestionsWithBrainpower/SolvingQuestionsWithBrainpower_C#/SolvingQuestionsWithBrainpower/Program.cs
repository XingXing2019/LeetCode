using System;

namespace SolvingQuestionsWithBrainpower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public long MostPoints_N2(int[][] questions)
        {
            var dp = new long[questions.Length][];
            dp[0] = new long[] { questions[0][0], 0 };
            for (int i = 1; i < questions.Length; i++)
            {
                dp[i] = new long[2];
                long max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (questions[j][1] + j < i)
                        max = Math.Max(max, dp[j][0]);
                }
                dp[i][0] = questions[i][0] + max;
                dp[i][1] = Math.Max(dp[i - 1][0], dp[i - 1][1]);
            }
            return Math.Max(dp[^1][0], dp[^1][1]);
        }

        public long MostPoints_N(int[][] questions)
        {
            var dp = new long[questions.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[2];
                dp[i][0] = questions[i][0];
            }
            var res = dp[^1][0];
            for (int i = questions.Length - 2; i >= 0; i--)
            {
                if (i + questions[i][1] + 1 < dp.Length)
                    dp[i][0] += Math.Max(dp[i + questions[i][1] + 1][0], dp[i + questions[i][1] + 1][1]);
                dp[i][1] = Math.Max(dp[i + 1][0], dp[i + 1][1]);
                res = Math.Max(dp[i][0], dp[i][1]);
            }
            return res;
        }
    }
}
