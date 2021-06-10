using System;
using System.Linq;

namespace CuttingRibbons
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaxLength(int[] ribbons, int k)
		{
			int li = 1, hi = ribbons.Max();
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				int segments = ribbons.Sum(x => x / mid);
				if (segments < k)
					hi = mid - 1;
				else
					li = mid + 1;
			}
			return hi;
		}
	}
}
