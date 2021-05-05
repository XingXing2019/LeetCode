using System;
using System.Collections;
using System.Collections.Generic;

namespace RevealCardsInIncreasingOrder
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] deck = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			Console.WriteLine(DeckRevealedIncreasing(deck));
		}
		public static int[] DeckRevealedIncreasing(int[] deck)
		{
			var queue = new Queue<int>();
			for (int i = 0; i < deck.Length; i++)
				queue.Enqueue(i);
			Array.Sort(deck);
			var res = new int[deck.Length];
			foreach (var card in deck)
			{
				res[queue.Dequeue()] = card;
				if(queue.Count != 0)
					queue.Enqueue(queue.Dequeue());
			}
			return res;
		}
	}
}
