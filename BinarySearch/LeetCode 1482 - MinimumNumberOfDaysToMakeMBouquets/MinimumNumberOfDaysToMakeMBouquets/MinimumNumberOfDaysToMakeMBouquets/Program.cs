using System;
using System.Linq;

namespace MinimumNumberOfDaysToMakeMBouquets
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] bloomDay = {1, 10, 3, 10, 2};
			int m = 3, k = 1;
			Console.WriteLine(MinDays(bloomDay, m, k));
		}
		public static int MinDays(int[] bloomDay, int m, int k)
		{
			int li = 1, hi = bloomDay.Max(), res = int.MaxValue;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				int count = 0, flowers = 0;
				foreach (var day in bloomDay)
				{
					if (day <= mid)
						flowers++;
					else
						flowers = 0;
					if (flowers != k) continue;
					flowers = 0;
					count++;
				}
				if (count >= m)
				{
					hi = mid - 1;
					res = Math.Min(res, mid);
				}
				else
					li = mid + 1;
			}
			return res == int.MaxValue ? -1 : res;
		}
	}
}
