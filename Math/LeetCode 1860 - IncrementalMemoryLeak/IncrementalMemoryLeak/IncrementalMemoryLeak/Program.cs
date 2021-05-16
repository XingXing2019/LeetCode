using System;

namespace IncrementalMemoryLeak
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] MemLeak(int memory1, int memory2)
		{
			double diff = Math.Abs(memory1 - memory2);
			int start = ((int) Math.Sqrt(1 + 4 * diff) - 1) / 2;
			if (memory1 > memory2)
				memory1 -= (1 + start) * start / 2;
			else 
				memory2 -= (1 + start) * start / 2;
			while (memory1 > start || memory2 > start)
			{
				start++;
				if (memory1 >= memory2)
					memory1 -= start;
				else
					memory2 -= start;
			}
			return new[] {start + 1, memory1, memory2};
		}
	}
}
