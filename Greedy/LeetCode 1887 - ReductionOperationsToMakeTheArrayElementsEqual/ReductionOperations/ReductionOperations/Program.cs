using System;
using System.Linq;

namespace ReductionOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int ReductionOperations(int[] nums)
		{
			var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
			var record = dict.Select(x => x.Key).OrderBy(x => x).ToArray();
			for (int i = 0; i < record.Length; i++)
				dict[record[i]] *= i;
			return dict.Sum(x => x.Value);
		}
	}
}
