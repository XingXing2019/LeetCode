using System;
using System.Linq;

namespace BestTeamWithNoConflicts
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 1, 3, 7, 3, 2, 4, 10, 7, 5 };
            int[] ages = { 4, 5, 2, 1, 1, 2, 4, 1, 4 };
            Console.WriteLine(BestTeamScore(scores, ages));
        }
        static int BestTeamScore(int[] scores, int[] ages)
        {
            var record = new int[scores.Length][];
            for (int i = 0; i < scores.Length; i++)
                record[i] = new[] {ages[i], scores[i]};
            record = record.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            var dp = new int[scores.Length];
            var res = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = record[i][1];
                for (int j = 0; j < i; j++)
                    dp[i] = record[i][0] == record[j][0] || record[j][1] <= record[i][1] 
                        ? dp[i] = Math.Max(dp[i], dp[j] + record[i][1]) : dp[i];
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }
}
