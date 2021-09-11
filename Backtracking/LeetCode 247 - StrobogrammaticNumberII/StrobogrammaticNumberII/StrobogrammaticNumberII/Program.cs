using System;
using System.Collections.Generic;

namespace StrobogrammaticNumberII
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 3;
			FindStrobogrammatic(n);
		}
		public static IList<string> FindStrobogrammatic(int n)
		{
			if (n == 1) return new List<string> {"0", "1", "8"};
			var dict = new Dictionary<char, char> {{'0', '0'}, {'1', '1'}, {'6', '9'}, {'8', '8'}, {'9', '6'}};
			var mid = new List<char> {'0', '1', '8'};
			var res = new List<string>();
			List<string> firstHalf = new List<string>(), secHalf = new List<string>();
			DFS(n / 2, "", "", firstHalf, secHalf, dict);
			for (int i = 0; i < firstHalf.Count; i++)
			{
				if(firstHalf[i].StartsWith("0")) continue;
				if(n % 2 == 0) 
					res.Add(firstHalf[i] + secHalf[i]);
				else
				{
					foreach (var digit in mid)
						res.Add(firstHalf[i] + digit + secHalf[i]);
				}
			}
			return res;
		}

		public static void DFS(int digits, string front, string back, List<string> firstHalf, List<string> secHalf, Dictionary<char, char> dict)
		{
			if (front.Length == digits)
			{
				firstHalf.Add(front);
				secHalf.Add(back);
				return;
			}
			foreach (var pair in dict)
				DFS(digits, front + pair.Key, pair.Value + back, firstHalf, secHalf, dict);
		}
	}
}
