using System;
using System.Collections.Generic;

namespace ProductOfTwoRunLengthEncodedArrays
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<IList<int>> FindRLEArray(int[][] encoded1, int[][] encoded2)
		{
			var res = new List<IList<int>>();
			int p1 = 0, p2 = 0;
			while (p1 < encoded1.Length && p2 < encoded2.Length)
			{
				var product = encoded1[p1][0] * encoded2[p2][0];
				var less = Math.Min(encoded1[p1][1], encoded2[p2][1]);
				if (res.Count == 0 || product != res[^1][0])
					res.Add(new List<int> { product, less });
				else
					res[^1][1] += less;
				encoded1[p1][1] -= less;
				encoded2[p2][1] -= less;
				if (encoded1[p1][1] == 0) p1++;
				if (encoded2[p2][1] == 0) p2++;
			}
			return res;
		}
	}
}
