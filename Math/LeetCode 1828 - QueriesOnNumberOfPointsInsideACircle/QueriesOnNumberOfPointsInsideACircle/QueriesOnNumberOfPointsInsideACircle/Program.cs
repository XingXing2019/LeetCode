using System;
using System.Linq;

namespace QueriesOnNumberOfPointsInsideACircle
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] CountPoints(int[][] points, int[][] queries)
		{
			var res = new int[queries.Length];
			for (int i = 0; i < queries.Length; i++)
			{
				res[i] = points.Count(x =>
					Math.Abs(x[0] - queries[i][0]) * Math.Abs(x[0] - queries[i][0]) +
					Math.Abs(x[1] - queries[i][1]) * Math.Abs(x[1] - queries[i][1]) <= queries[i][2] * queries[i][2]);
			}
			return res;
		}
	}
}
