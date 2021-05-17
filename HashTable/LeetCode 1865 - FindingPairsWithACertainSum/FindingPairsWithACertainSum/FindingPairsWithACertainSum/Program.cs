using System;
using System.Collections.Generic;

namespace FindingPairsWithACertainSum
{
	class Program
	{
		static void Main(string[] args)
		{
			var pair = new FindSumPairs(new[] {1, 1, 2, 2, 2, 3}, new[] {1, 4, 5, 2, 5, 4});
			Console.WriteLine(pair.Count(7));
			pair.Add(3, 2);
			Console.WriteLine(pair.Count(8));
			Console.WriteLine(pair.Count(4));
			pair.Add(0, 1);
			pair.Add(1, 1);
			Console.WriteLine(pair.Count(7));
		}
	}
	public class FindSumPairs
	{
		private Dictionary<int, int> dict1;
		private Dictionary<int, int> dict2;
		private int[] record;
		public FindSumPairs(int[] nums1, int[] nums2)
		{
			record = nums2;
			dict1 = new Dictionary<int, int>();
			dict2 = new Dictionary<int, int>();
			foreach (var num in nums1)
			{
				if (!dict1.ContainsKey(num))
					dict1[num] = 0;
				dict1[num]++;
			}
			foreach (var num in nums2)
			{
				if (!dict2.ContainsKey(num))
					dict2[num] = 0;
				dict2[num]++;
			}
		}

		public void Add(int index, int val)
		{
			var num = record[index];
			dict2[num]--;
			if (dict2[num] == 0)
				dict2.Remove(num);
			if (!dict2.ContainsKey(num + val))
				dict2[num + val] = 0;
			dict2[num + val]++;
			record[index] = num + val;
		}

		public int Count(int tot)
		{
			int res = 0;
			foreach (var item in dict1)
			{
				if (dict2.ContainsKey(tot - item.Key))
					res += item.Value * dict2[tot - item.Key];
			}
			return res;
		}
	}
}
