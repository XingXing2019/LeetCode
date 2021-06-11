using System;
using FindTheIndexOfTheLargeInteger;

namespace FindTheIndexOfTheLargeInteger
{
	class ArrayReader
	{
		public int CompareSub(int l, int r, int x, int y) => 0;

		public int Length() => 0;
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int GetIndex(ArrayReader reader)
		{
			int li = 0, hi = reader.Length() - 1;
			while (li < hi)
			{
				int mid = li + (hi - li) / 2;
				if (mid - li + 1 == hi - mid)
				{
					if (reader.CompareSub(li, mid, mid + 1, hi) < 0)
						li = mid + 1;
					else
						hi = mid;
				}
				else
				{
					int res = reader.CompareSub(li + 1, mid, mid + 1, hi);
					if (res == 0)
						return li;
					if (res > 0)
						hi = mid;
					else
						li = mid + 1;
				}
			}
			return li;
		}
	}
}
