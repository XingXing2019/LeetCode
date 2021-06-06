using System;

namespace EggDropWith2EggsAndNFloors
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int TwoEggDrop(int n)
		{
			return (int) Math.Ceiling((Math.Sqrt(1 + 8 * n) - 1) / 2);
		}
	}
}
