using System;
using System.Collections.Generic;

namespace FindUniqueBinaryString
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string FindDifferentBinaryString(string[] nums)
		{
			var set = new HashSet<string>(nums);
			for (int i = 0; i < nums.Length; i++)
			{
				var num = ToBinaryString(i, nums.Length);
				if (!set.Contains(num))
					return num;
			}
			return ToBinaryString(nums.Length, nums.Length);
		}

		public string ToBinaryString(int num, int len)
		{
			var res = "";
			while (num != 0)
			{
				res = num % 2 + res;
				num /= 2;
			}
			return new string('0', len - res.Length) + res;
		}
	}
}
