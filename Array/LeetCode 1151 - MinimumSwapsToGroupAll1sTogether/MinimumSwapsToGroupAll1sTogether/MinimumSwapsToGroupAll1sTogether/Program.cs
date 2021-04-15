using System;
using System.Linq;

namespace MinimumSwapsToGroupAll1sTogether
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] data = { 1, 0, 1, 0, 1 };
			Console.WriteLine(MinSwaps(data));
		}
		public static int MinSwaps(int[] data)
		{
			int ones = data.Count(x => x == 1);
			int li = 0, hi = 0, zeros = 0, res = int.MaxValue;
			for (int i = 0; i < ones; i++)
				zeros += data[hi++] == 0 ? 1 : 0;
			while (hi < data.Length)
			{
				res = Math.Min(res, zeros);
				if (data[li++] == 0)
					zeros--;
				if (data[hi++] == 0)
					zeros++;
			}
			res = Math.Min(res, zeros);
			return res;
		}
	}
}
