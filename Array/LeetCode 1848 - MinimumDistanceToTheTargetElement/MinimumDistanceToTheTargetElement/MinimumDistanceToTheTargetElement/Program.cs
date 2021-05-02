using System;

namespace MinimumDistanceToTheTargetElement
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int GetMinDistance(int[] nums, int target, int start)
		{
			int res = int.MaxValue;
			for (int i = 0; i < nums.Length; i++)
			{
				if(nums[i] != target) continue;
				res = Math.Min(res, Math.Abs(i - start));
			}
			return res;
		}
	}
}
