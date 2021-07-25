using System;

namespace SumOfDigitsOfStringAfterConvert
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "leetcode";
			var k = 2;
			Console.WriteLine(GetLucky(s, k));
		}
		public static int GetLucky(string s, int k)
		{
			var num = "";
			foreach (var l in s)
				num += l - 'a' + 1;
			var res = 0;
			for (int i = 0; i < k; i++)
			{
				res = 0;
				foreach (var l in num)
					res += l - '0';
				num = res.ToString();
			}
			return res;
		}
	}
}
