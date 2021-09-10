using System;
using System.Collections.Generic;

namespace SmallestGreaterMultipleMadeOfTwoDigits
{
	class Program
	{
		static void Main(string[] args)
		{
			int k = 3, digit1 = 4, digit2 = 2;
			Console.WriteLine(FindInteger(k, digit1, digit2));
		}

		
		public static int FindInteger(int k, int digit1, int digit2)
		{
			long res = -1;
			DFS(k, digit1, digit2, 0, new HashSet<long>(), ref res);
			return (int) res;
		}

		public static void DFS(int k, int digit1, int digit2, long num, HashSet<long> visited, ref long res)
		{
			if(res != -1 && num > res || !visited.Add(num) || num > int.MaxValue)
				return;
			if (num % k == 0 && num > k)
			{
				res = num;
				return;
			}
			DFS(k, digit1, digit2, num * 10 + digit1, visited, ref res);
			DFS(k, digit1, digit2, num * 10 + digit2, visited, ref res);
		}
	}
}
