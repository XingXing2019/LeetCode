using System;
using System.Linq;

namespace RemoveStonesToMinimizeTheTotal
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinStoneSum(int[] piles, int k)
		{
			int max = piles.Max(), res = 0;
			var record = new int[max + 1];
			foreach (var pile in piles)
				record[pile]++;
			for (int i = record.Length - 1; i >= 0 && k > 0; i--)
			{
				if(record[i] == 0) continue;
				while (k > 0 && record[i] != 0)
				{
					record[i - i / 2]++;
					record[i]--;
					k--;
				}
			}
			for (int i = 0; i < record.Length; i++)
			{
				if (record[i] == 0) continue;
				res += i * record[i];
			}
			return res;
		}
	}
}
