using System;
using System.Collections.Generic;

namespace LongestCommonSubsequence
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<int> LongestCommomSubsequence(int[][] arrays)
		{
			var pointers = new int[arrays.Length];
			var res = new List<int>();
			int num = 0;
			foreach (var arr in arrays)
				num = Math.Max(num, arr[0]);
			while (num <= 100)
			{
				int max = 0;
				var allSame = true;
				for (int i = 0; i < arrays.Length; i++)
				{
					while (pointers[i] < arrays[i].Length && arrays[i][pointers[i]] < num)
						pointers[i]++;
					if (pointers[i] >= arrays[i].Length)
						return res;
					max = Math.Max(max, arrays[i][pointers[i]]);
					if (arrays[i][pointers[i]] == num) continue;
					allSame = false;
					break;
				}
				if (allSame)
				{
					res.Add(num);
					num++;
				}
				else
					num = max;
			}
			return res;
		}
	}
}
