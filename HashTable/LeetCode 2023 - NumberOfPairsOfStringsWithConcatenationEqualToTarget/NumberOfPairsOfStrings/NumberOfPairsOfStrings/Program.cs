using System;
using System.Collections.Generic;

namespace NumberOfPairsOfStrings
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] nums = {"74", "1", "67", "1", "74"};
			var target = "174";
			Console.WriteLine(NumOfPairs(nums, target));
		}

		public static int NumOfPairs(string[] nums, string target)
		{
			var dict = new Dictionary<string, int>();
			int res = 0;
			foreach (var num in nums)
			{
				if (target.Length > num.Length && target.Substring(0, num.Length) == num)
				{
					var back = target.Substring(num.Length);
					if (dict.ContainsKey(back))
						res += dict[back];
				}
				if (target.Length > num.Length && target.Substring(target.Length - num.Length) == num)
				{
					var front = target.Substring(0, target.Length - num.Length);
					if (dict.ContainsKey(front))
						res += dict[front];
				}
				if (!dict.ContainsKey(num))
					dict[num] = 0;
				dict[num]++;
			}
			return res;
		}
	}
}
