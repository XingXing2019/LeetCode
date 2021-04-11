using System;
using System.Collections.Generic;

namespace FindTheWinnerOfTheCircularGame
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 10, k = 8;
			Console.WriteLine(FindTheWinner(n, k));
		}
		public static int FindTheWinner(int n, int k)
		{
			var queue = new Queue<int>();
			for (int i = 1; i <= n; i++)
				queue.Enqueue(i);
			while (queue.Count != 1)
			{
				var times = k % queue.Count == 0 ? queue.Count : k % queue.Count;
				for (int i = 0; i < times; i++)
				{
					var temp = queue.Dequeue();
					if(i != times - 1)
						queue.Enqueue(temp);
				}	
			}
			return queue.Dequeue();
		}
	}
}
