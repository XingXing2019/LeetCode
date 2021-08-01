using System;
using System.Linq;

namespace MaximumNumberOfWeeks
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public long NumberOfWeeks(int[] milestones)
		{
			int max = milestones.Max();
			long rest = 0, count = 0;
			foreach (var milestone in milestones)
			{
				if (milestone != max)
					rest += milestone;
				else
					count++;
			}
			return count > 1 ? rest + max * count : rest + Math.Min(max, rest + 1);
		}
	}
}
