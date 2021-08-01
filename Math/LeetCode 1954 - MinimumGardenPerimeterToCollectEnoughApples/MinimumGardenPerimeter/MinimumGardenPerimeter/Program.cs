using System;

namespace MinimumGardenPerimeter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public long MinimumPerimeter(long neededApples)
		{
			long x = 1;
			while (2 * x * (x - 1) * (2 * x - 1) < neededApples)
				x++;
			return (x - 1) * 8;
		}
	}
}
