using System;

namespace CountSortedVowelStrings
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
        public int CountVowelStrings(int n)
        {
            int[,] dp = new int[n, 5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j > 0)
                        dp[i, j] = dp[i, j - 1];
                    if (i > 0)
                        dp[i, j] += dp[i - 1, j];
                    else
                        dp[i, j] = j + 1;
                }
            }
            return dp[n - 1, 4];
        }
    }
}
