using System;

namespace MinimumCostToSeparateSentenceIntoRows
{
	class Program
	{
		static void Main(string[] args)
		{
			var sentence = "i love leetcode aaaa";
			int k = 12;
			Console.WriteLine(MinimumCost(sentence, k));
		}

		public static int MinimumCost(string sentence, int k, int start = 0)
		{
			return DFS(sentence, k, 0);
		}

		public static int DFS(string sentence, int k, int start)
		{
			if (start + k >= sentence.Length)
				return 0;
			int res = int.MaxValue;
			for (int i = start; i - start <= k; i++)
			{
				if (sentence[i] == ' ')
					res = Math.Min(res, (k - i + start) * (k - i + start) + DFS(sentence, k, i + 1));
			}
			return res;
		}
	}
}
