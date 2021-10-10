using System;
using System.Collections.Generic;

namespace MinimumOperationsToMakeAUniValueGrid
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinOperations(int[][] grid, int x)
		{
			var nums = new List<int>();
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[0].Length; j++)
				{
					nums.Add(grid[i][j]);
				}
			}
			nums.Sort();
			int median = nums[(nums.Count - 1) / 2];
			int res = 0;
			for (int i = 0; i < nums.Count; i++)
			{
				if(nums[i] == median) continue;
				if (Math.Abs(nums[i] - median) % x != 0)
					return -1;
				res += Math.Abs(nums[i] - median) / x;
			}
			return res;
		}
	}
}
