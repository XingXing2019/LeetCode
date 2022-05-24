using System;

namespace LongestValidParentheses
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int LongestValidParentheses(string s)
		{
			int left = 0, right = 0, res = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(') left++;
				else right++;
				if (right > left)
				{
					left = 0;
					right = 0;
				}
				else if(left == right)
					res = Math.Max(res, 2 * right);
			}
			left = 0; right = 0;
			for (int i = s.Length - 1; i >= 0; i--)
			{
				if (s[i] == '(') left++;
				else right++;
				if (left > right)
				{
					left = 0;
					right = 0;
				}
				else if (left == right)
					res = Math.Max(res, 2 * left);
			}
			return res;
		}
	}
}
