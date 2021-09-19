using System;
using System.Collections.Generic;

namespace FindOriginalArrayFromDoubledArray
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] changed = {6, 3, 0, 1};
			Console.WriteLine(FindOriginalArray(changed));
		}

		public static int[] FindOriginalArray(int[] changed)
		{
			if (changed.Length % 2 != 0) return new int[0];
			Array.Sort(changed);
			var dict = new Dictionary<int, int>();
			int[] res = new int[changed.Length / 2];
			int index = 0;
			for (int i = changed.Length - 1; i >= 0; i--)
			{
				int num = changed[i];
				if (!dict.ContainsKey(num))
					dict[num] = 0;
				dict[num]++;
				if (dict.ContainsKey(num * 2) && dict[num * 2] > (num == 0 ? 1 : 0))
				{
					res[index++] = num;
					dict[num]--;
					dict[num * 2]--;
				}
			}
			return index == res.Length ? res : new int[0];
		}
	}
}
