using System;

namespace CountSpecialQuadruplets
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {1, 1, 1, 3, 5};
			Console.WriteLine(CountQuadruplets(nums));
		}
		public static int CountQuadruplets(int[] nums)
		{
			int res = 0;
			for (int i = 0; i < nums.Length - 3; i++)
			{
				for (int j = i + 1; j < nums.Length - 2; j++)
				{
					for (int k = j + 1; k < nums.Length - 1; k++)
					{
						for (int l = k + 1; l < nums.Length; l++)
						{
							if (nums[i] + nums[j] + nums[k] == nums[l])
								res++;
						}
					}
				}
			}
			return res;
		}
	}
}
