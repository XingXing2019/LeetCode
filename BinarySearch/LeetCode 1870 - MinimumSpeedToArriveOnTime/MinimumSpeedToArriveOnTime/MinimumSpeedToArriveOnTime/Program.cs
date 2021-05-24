using System;

namespace MinimumSpeedToArriveOnTime
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinSpeedOnTime(int[] dist, double hour)
		{
			int li = 0, hi = int.MaxValue;
			while (li < hi)
			{
				int mid = li + (hi - li) / 2;
				double time = 0;
				for (int i = 0; i < dist.Length; i++)
					time += i == dist.Length - 1 ? (double) dist[i] / mid : Math.Ceiling((double) dist[i] / mid);
				if (time <= hour)
					hi = mid;
				else
					li = mid + 1;
			}
			return li == int.MaxValue ? -1 : li;
		}
	}
}
