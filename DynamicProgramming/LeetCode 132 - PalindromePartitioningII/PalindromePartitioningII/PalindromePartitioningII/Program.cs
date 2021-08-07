using System;

namespace PalindromePartitioningII
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "abbab";
			Console.WriteLine(MinCut(s));
		}
		public static int MinCut(string s)
		{
			var dp = new int[s.Length];
			for (int i = 1; i < dp.Length; i++)
			{
				int min = int.MaxValue;
				for (int j = 0; j <= i; j++)
				{
					if (IsPalindrome(s, j, i))
						min = Math.Min(min, j == 0 ? 0 : dp[j - 1] + 1);
				}
				dp[i] = min;
			}
			return dp[^1];
		}

		public static bool IsPalindrome(string s, int li, int hi)
		{
			while (li < hi)
			{
				if (s[li++] != s[hi--])
					return false;
			}
			return true;
		}
	}
}
