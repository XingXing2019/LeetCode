using System;
using System.Globalization;

namespace InterleavingString
{
	class Program
	{
		static void Main(string[] args)
		{
			string s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac";
			Console.WriteLine(IsInterleave(s1, s2, s3));
		}
		public static bool IsInterleave(string s1, string s2, string s3)
		{
			if (s1.Length + s2.Length != s3.Length) return false;
			if (s1 == "") return s2 == s3;
			if (s2 == "") return s1 == s3;
			var dp = new bool[s1.Length + 1][];
			for (int i = 0; i < dp.Length; i++)
				dp[i] = new bool[s2.Length + 1];
			dp[0][0] = true;
			for (int i = 1; i < dp.Length; i++)
				dp[i][0] = dp[i - 1][0] && s1[i - 1] == s3[i - 1];
			for (int i = 1; i < dp[0].Length; i++)
				dp[0][i] = dp[0][i - 1] && s2[i - 1] == s3[i - 1];
			for (int i = 1; i < dp.Length; i++)
			{
				for (int j = 1; j < dp[0].Length; j++)
				{
					if (dp[i - 1][j] && dp[i][j - 1])
						dp[i][j] = s1[i - 1] == s3[i + j - 1] || s2[j - 1] == s3[i + j - 1];
					else if (dp[i - 1][j])
						dp[i][j] = s1[i - 1] == s3[i + j - 1];
					else if (dp[i][j - 1])
						dp[i][j] = s2[j - 1] == s3[i + j - 1];
				}
			}
			return dp[^1][^1];
		}
	}
}
