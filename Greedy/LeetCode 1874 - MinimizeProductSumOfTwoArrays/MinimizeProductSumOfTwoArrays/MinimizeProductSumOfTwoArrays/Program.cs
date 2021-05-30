using System;

namespace MinimizeProductSumOfTwoArrays
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinProductSum(int[] nums1, int[] nums2)
		{
			Array.Sort(nums1);
			Array.Sort(nums2, (a, b) => b - a);
			var res = 0;
			for (int i = 0; i < nums1.Length; i++)
				res += nums1[i] * nums2[i];
			return res;
		}
	}
}
