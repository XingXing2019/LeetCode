using System;
using System.Collections.Generic;

namespace BeautifulArray
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			Console.WriteLine(BeautifulArray(n));
		}
		public static int[] BeautifulArray(int n)
		{
			var res = new List<int> {1};
			while (res.Count < n)
			{
				var temp = new List<int>();
				foreach (var num in res)
				{
					if(num * 2 - 1 <= n)
						temp.Add(num * 2 - 1);
				}
				foreach (var num in res)
				{
					if(num * 2 <= n)
						temp.Add(num * 2);
				}
				res = temp;
			}
			return res.ToArray();
		}
	}
}
