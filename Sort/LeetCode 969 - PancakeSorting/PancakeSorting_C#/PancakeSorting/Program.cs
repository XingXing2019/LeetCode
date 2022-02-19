using System;
using System.Collections.Generic;

namespace PancakeSorting
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = {3, 2, 4, 1};
			Console.WriteLine(PancakeSort(arr));
		}
		public static IList<int> PancakeSort(int[] arr)
		{
			List<int> target = new List<int>(arr), res = new List<int>();
			target.Sort();
			for (int i = target.Count - 1; i >= 0; i--)
			{
				var index = Array.IndexOf(arr, target[i]);
				res.Add(index + 1);
				Array.Reverse(arr, 0, res[^1]);
				res.Add(i + 1);
				Array.Reverse(arr, 0, res[^1]);
			}
			return res;
		}
	}
}
