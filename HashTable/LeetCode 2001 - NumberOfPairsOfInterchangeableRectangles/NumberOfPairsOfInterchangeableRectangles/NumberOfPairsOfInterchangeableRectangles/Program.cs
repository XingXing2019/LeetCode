using System;
using System.Collections.Generic;

namespace NumberOfPairsOfInterchangeableRectangles
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public long InterchangeableRectangles(int[][] rectangles)
		{
			var dict = new Dictionary<double, int>();
			long res = 0;
			foreach (var rectangle in rectangles)
			{
				var ratio = (double) rectangle[0] / rectangle[1];
				if (!dict.ContainsKey(ratio))
					dict[ratio] = 0;
				res += dict[ratio];
				dict[ratio]++;
			}
			return res;
		}
	}
}
