using System;

namespace FindTheKthLargestIntegerInTheArray
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] nums = {"3", "6", "7", "10"};
			int k = 4;
			Console.WriteLine(KthLargestNumber(nums, k));
		}

		public static string KthLargestNumber(string[] nums, int k)
		{
			Array.Sort(nums, Compare);
			return nums[k - 1];
		}

		public static int Compare(string num1, string num2)
		{
			if (num1.Length > num2.Length) return -1;
			if (num1.Length < num2.Length) return 1;
			for (int i = 0; i < num1.Length; i++)
			{
				if (num1[i] > num2[i]) return -1;
				if (num1[i] < num2[i]) return 1;
			}
			return 0;
		}
	}
}
