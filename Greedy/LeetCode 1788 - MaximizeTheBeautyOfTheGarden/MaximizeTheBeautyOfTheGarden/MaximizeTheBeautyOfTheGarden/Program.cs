using System;
using System.Collections.Generic;

namespace MaximizeTheBeautyOfTheGarden
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] flowers = { -1, -2, 0, -1 };
			Console.WriteLine(MaximumBeauty(flowers));
		}
		public static int MaximumBeauty(int[] flowers)
		{
			var pairs = new Dictionary<int, List<int>>();
			for (int i = 0; i < flowers.Length; i++)
			{
				if (!pairs.ContainsKey(flowers[i]))
					pairs[flowers[i]] = new List<int> {i};
			}
			for (int i = flowers.Length - 1; i >= 0; i--)
			{
				if (pairs[flowers[i]].Count == 2) continue;
				if (pairs[flowers[i]][0] == i)
					pairs.Remove(flowers[i]);
				else
					pairs[flowers[i]].Add(i);
			}
			int res = int.MinValue;
			var prefix = new int[flowers.Length];
			for (int i = 0; i < prefix.Length; i++)
				prefix[i] = Math.Max(0, flowers[i]) + (i == 0 ? 0 : prefix[i - 1]);
			foreach (var pair in pairs)
			{
				int sum = prefix[pair.Value[1] - 1] - prefix[pair.Value[0]];
				res = Math.Max(res, sum + pair.Key * 2);
			}
			return res;
		}
	}
}
