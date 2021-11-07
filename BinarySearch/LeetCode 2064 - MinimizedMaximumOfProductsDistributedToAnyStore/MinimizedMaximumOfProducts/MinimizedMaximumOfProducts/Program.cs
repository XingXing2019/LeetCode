using System;

namespace MinimizedMaximumOfProducts
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int MinimizedMaximum(int n, int[] quantities)
		{
			long sum = 0;
			foreach (var quantity in quantities)
				sum += quantity;
			long li = 1, hi = sum;
			while (li < hi)
			{
				long mid = li + (hi - li) / 2, count = 0;
				foreach (var quantity in quantities)
					count += (int)Math.Ceiling((double)quantity / mid);
				if (count > n)
					li = mid + 1;
				else
					hi = mid;
			}
			return (int)li;
		}
	}
}
