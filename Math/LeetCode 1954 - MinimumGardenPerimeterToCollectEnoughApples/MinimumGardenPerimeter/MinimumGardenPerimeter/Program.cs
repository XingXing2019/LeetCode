using System;

namespace MinimumGardenPerimeter
{
	class Program
	{
		static void Main(string[] args)
		{
			int neededApples = 1;
			Console.WriteLine(MinimumPerimeter_BinarySearch(neededApples));
		}
		public long MinimumPerimeter(long neededApples)
		{
			long x = 1;
			while (2 * x * (x - 1) * (2 * x - 1) < neededApples)
				x++;
			return (x - 1) * 8;
		}

		public static long MinimumPerimeter_BinarySearch(long neededApples)
		{
			long li = 0, hi = 100000;
			while (li <= hi)
			{
				long mid = li + (hi - li) / 2;
				if (2 * mid * (mid - 1) * (2 * mid - 1) < neededApples)
					li = mid + 1;
				else
					hi = mid - 1;
			}
			return hi * 8;
		}
	}
}
