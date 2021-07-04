using System;

namespace EliminateMaximumNumberOfMonsters
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int EliminateMaximum(int[] dist, int[] speed)
		{
			var reachIn = new double[dist.Length];
			for (int i = 0; i < reachIn.Length; i++)
				reachIn[i] = (double) dist[i] / speed[i];
			Array.Sort(reachIn);
			int timer = 0, index = 0;
			while (index < reachIn.Length && reachIn[index] > timer)
			{
				index++;
				timer++;
			}
			return index;
		}
	}
}
