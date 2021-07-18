using System;

namespace AddMinimumNumberOfRungs
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] runng = {1, 3, 5, 10};
			int dist = 2;
			Console.WriteLine(AddRungs(runng, dist));
		}
		public static int AddRungs(int[] rungs, int dist)
		{
			int res = 0;
			for (int i = 0; i < rungs.Length; i++)
			{
				double gap = i == 0 ? rungs[i] - 1 : rungs[i] - rungs[i - 1] - 1;
				res += (int) Math.Floor(gap / dist);
			}
			return res;
		}
	}
}
