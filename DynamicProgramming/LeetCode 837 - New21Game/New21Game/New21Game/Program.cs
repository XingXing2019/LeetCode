using System;
using System.Linq;

namespace New21Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double New21Game(int n, int k, int maxPts)
        {
            if (n >= k - 1 + maxPts || n == 0) return 1.0;
            if (n < k) return 0.0;
            double sum = 1, res = 0;
            var dp = new double[n + 1];
            dp[0] = 1.0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = sum / maxPts;
                if (i >= maxPts) sum -= dp[i - maxPts];
                if (i < k) sum += dp[i];
            }
            for (int i = k; i <= n; i++)
                res += dp[i];
            return Math.Min(res, 1);
        }
    }
}
