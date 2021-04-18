using System;

namespace MaximumIceCreamBars
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaxIceCream(int[] costs, int coins)
		{
			Array.Sort(costs);
			int res = 0;
			foreach (var cost in costs)
			{
				if (coins - cost < 0)
					return res;
				coins -= cost;
				res++;
			}
			return res;
		}
	}
}
