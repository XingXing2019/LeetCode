using System;

namespace JumpGameVII
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool CanReach(string s, int minJump, int maxJump)
		{
			var dp = new bool[s.Length];
			int pre = 0;
			dp[0] = true;
			for (int i = 1; i < dp.Length; i++)
			{
				if (i >= minJump && dp[i - minJump])
					pre++;
				if (i > maxJump && dp[i - maxJump - 1])
					pre--;
				if (pre > 0 && s[i] == '0')
					dp[i] = true;
			}
			return dp[^1];
		}
	}
}
