using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumNumberOfSwaps
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinSwaps(string s)
		{
			int countZero = s.Count(x => x == '0');
			int countOne = s.Count(x => x == '1');
			if (Math.Abs(countZero - countOne) > 1) return -1;
			var strs = Build(countZero, countOne);
			int res = s.Length;
			foreach (var str in strs)
			{
				int count = 0;
				for (int i = 0; i < str.Length; i++)
				{
					if (s[i] != str[i])
						count++;
				}
				res = Math.Min(res, count / 2);
			}
			return res;
		}

		public List<string> Build(int countZero, int countOne)
		{
			var str1 = new StringBuilder();
			var str2 = new StringBuilder();
			if (countZero > countOne)
			{
				for (int i = 0; i < countOne; i++)
					str1.Append("01");
				str1.Append('0');
				return new List<string> {str1.ToString()};
			}
			if (countZero < countOne)
			{
				for (int i = 0; i < countZero; i++)
					str1.Append("10");
				str1.Append('1');
				return new List<string> {str1.ToString()};
			}
			for (int i = 0; i < countOne; i++)
			{
				str1.Append("01");
				str2.Append("10");
			}
			return new List<string> {str1.ToString(), str2.ToString()};
		}
	}
}
