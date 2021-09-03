using System;
using System.Collections.Generic;

namespace MaximumNumberOfPeople
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] team = { 1, 1, 1, 1, 0, 0, 0, 0 };
			int dist = 2;
			Console.WriteLine(CatchMaximumAmountofPeople(team, dist));
		}
		public static int CatchMaximumAmountofPeople(int[] team, int dist)
		{
			Queue<int> ones = new Queue<int>(), zeros = new Queue<int>();
			for (int i = 0; i < team.Length; i++)
			{
				if(team[i] == 0)
					zeros.Enqueue(i);
				else
					ones.Enqueue(i);
			}
			int res = 0;
			while (zeros.Count != 0 && ones.Count != 0)
			{
				if (zeros.Peek() < ones.Peek())
				{
					while (zeros.Count != 0 && ones.Peek() - zeros.Peek() > dist)
						zeros.Dequeue();
					if (zeros.Count == 0) continue;
					zeros.Dequeue();
					ones.Dequeue();
					res++;
				}
				else
				{
					while (ones.Count != 0 && zeros.Peek() - ones.Peek() > dist)
						ones.Dequeue();
					if (ones.Count == 0) continue;
					zeros.Dequeue();
					ones.Dequeue();
					res++;
				}
			}
			return res;
		}
	}
}
