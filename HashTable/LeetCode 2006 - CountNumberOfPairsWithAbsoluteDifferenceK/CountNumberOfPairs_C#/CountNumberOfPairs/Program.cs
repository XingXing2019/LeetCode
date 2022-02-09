using System;
using System.Collections.Generic;

namespace CountNumberOfPairs
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CountKDifference(int[] nums, int k)
		{
			var dict = new Dictionary<int, int>();
			var res = 0;
			foreach (var num in nums)
			{
				if (dict.ContainsKey(num - k))
					res += dict[num - k];
				if (dict.ContainsKey(k + num))
					res += dict[k + num];
				if (!dict.ContainsKey(num))
					dict[num] = 0;
				dict[num]++;
			}
			return res;
		}
	}
}
