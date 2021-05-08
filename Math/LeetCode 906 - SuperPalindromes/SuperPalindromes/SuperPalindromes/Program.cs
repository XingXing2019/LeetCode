using System;
using System.Text;

namespace SuperPalindromes
{
	class Program
	{
		static void Main(string[] args)
		{
			string left = "1000000000000000000";
			Console.WriteLine(long.Parse(left));
		}
		public int SuperpalindromesInRange(string left, string right)
		{
			long limit = 1_00_000;
			int res = 0;
			for (long i = 1; i < limit; i++)
			{
				string frontHalf = i.ToString();
				var str1 = new StringBuilder(frontHalf);
				var str2 = new StringBuilder(frontHalf);
				for (int j = frontHalf.Length - 2; j >= 0; j--)
					str1.Append(frontHalf[j]);
				var num = long.Parse(str1.ToString());
				for (int j = frontHalf.Length - 1; j >= 0; j--)
					str2.Append(frontHalf[j]);
				if ((num * num).ToString().Length > right.Length) break;
				if (IsValid(str1, left, right))
					res++;
				if (IsValid(str2, left, right))
					res++;
			}
			return res;
		}

		public bool IsValid(StringBuilder str, string left, string right)
		{
			long num = long.Parse(str.ToString());
			return num * num >= long.Parse(left) && num * num <= long.Parse(right) && IsPalindrome((num * num).ToString());
		}

		public bool IsPalindrome(string str)
		{
			int li = 0, hi = str.Length - 1;
			while (li < hi)
			{
				if (str[li++] != str[hi--])
					return false;
			}
			return true;
		}
	}
}
