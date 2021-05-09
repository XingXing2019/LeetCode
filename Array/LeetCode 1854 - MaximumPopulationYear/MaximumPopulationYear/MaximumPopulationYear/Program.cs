using System;
using System.Linq;

namespace MaximumPopulationYear
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaximumPopulation(int[][] logs)
		{
			var record = new int[101];
			int start = 1950, max = 0, res = 0, alive = 0;
			foreach (var log in logs)
			{
				record[log[0] - start]++;
				record[log[1] - start]--;
			}
			for (int i = 0; i < record.Length; i++)
			{
				alive += record[i];
				if (alive > max)
				{
					max = alive;
					res = i + start;
				}
			}
			return res;
		}
	}
}
