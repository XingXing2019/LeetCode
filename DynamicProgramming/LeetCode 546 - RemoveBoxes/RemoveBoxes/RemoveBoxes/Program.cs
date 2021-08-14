using System;

namespace RemoveBoxes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		
		public int RemoveBoxes(int[] boxes)
		{
			var dp = new int[boxes.Length][][];
			for (int i = 0; i < dp.Length; i++)
			{
				dp[i] = new int[boxes.Length][];
				for (int j = 0; j < dp[i].Length; j++)
				{
					dp[i][j] = new int[boxes.Length];
				}
			}
			return DFS(boxes, dp, 0, boxes.Length - 1, 0);
		}

		public int DFS(int[] boxes, int[][][] dp, int li, int hi, int k)
		{
			if (li > hi) return 0;
			while (li < hi && boxes[hi] == boxes[hi - 1])
			{
				hi--;
				k++;
			}
			if (dp[li][hi][k] > 0) return dp[li][hi][k];
			dp[li][hi][k] = DFS(boxes, dp, li, hi - 1, 0) + (k + 1) * (k + 1);
			for (int i = li; i < hi; i++)
			{
				if (boxes[i] == boxes[hi])
					dp[li][hi][k] = Math.Max(dp[li][hi][k], DFS(boxes, dp, li, i, k + 1) + DFS(boxes, dp, i + 1, hi - 1, 0));

			}
			return dp[li][hi][k];
		}
	}
}
