using System;
using System.Collections.Generic;
using System.Linq;

namespace AmbiguousCoordinates
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "(000123)";
			Console.WriteLine(AmbiguousCoordinates(s));
		}
		public static IList<string> AmbiguousCoordinates(string s)
		{
			var res = new List<string>();
			string digits = s.Substring(1, s.Length - 2);
			for (int i = 1; i < digits.Length; i++)
			{
				string n1 = digits.Substring(0, i);
				string n2 = digits.Substring(i);
				if (n1.Length != 1 && n1.All(x => x == '0') || n1.Length != 1 && n1.StartsWith('0') && n1.EndsWith('0') ||
				    n2.Length != 1 && n2.All(x => x == '0') || n2.Length != 1 && n2.StartsWith('0') && n2.EndsWith('0'))
					continue;
				var nums1 = AddPoint(n1);
				var nums2 = AddPoint(n2);
				foreach (var num1 in nums1)
				{
					foreach (var num2 in nums2)
					{
						res.Add($"({num1}, {num2})");
					}
				}
			}
			return res;
		}

		public static List<string> AddPoint(string n)
		{
			var res = new List<string>();
			if (n.StartsWith('0'))
			{
				string num = n == "0" ? n : $"0.{n.Substring(1)}";
				return new List<string> {num};
			}
			for (int i = 1; i <= n.Length; i++)
			{
				string num1 = n.Substring(0, i);
				string num2 = n.Length == 1 ? "" : n.Substring(i);
				if (num1.All(x => x == '0') || num2 != "" && (num2.All(x => x == '0') || num2.EndsWith('0')))
					continue;
				string num = num1;
				if (num2 != "") num += $".{num2}";
				res.Add(num);
			}
			return res;
		}
	}
}
