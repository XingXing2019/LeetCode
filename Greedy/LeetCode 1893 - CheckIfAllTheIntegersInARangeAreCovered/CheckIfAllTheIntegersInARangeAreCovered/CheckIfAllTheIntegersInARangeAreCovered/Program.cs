using System;
using System.Collections.Generic;

namespace CheckIfAllTheIntegersInARangeAreCovered
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public bool IsCovered(int[][] ranges, int left, int right)
		{
			var set = new HashSet<int>();
			for (int i = left; i <= right; i++)
				set.Add(i);
			foreach (var range in ranges)
			{
				for (int i = range[0]; i <= range[1]; i++)
					set.Remove(i);
			}
			return set.Count == 0;
		}
	}
}
