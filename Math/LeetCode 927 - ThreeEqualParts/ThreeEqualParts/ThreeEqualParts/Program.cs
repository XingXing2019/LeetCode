using System;
using System.Linq;

namespace ThreeEqualParts
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 0, 1, 0, 1, 1 };
			Console.WriteLine(ThreeEqualParts(arr));
		}

		public static int[] ThreeEqualParts(int[] arr)
		{
			var ones = arr.Count(x => x == 1);
			if (ones % 3 != 0) return new[] {-1, -1};
			int count = 0, p1 = 2, p2 = 1, countZero = 0;
			var parts = new string[3];
			var res = new int[2];
			for (int i = arr.Length - 1; i >= 0 && p1 >= 0; i--)
			{
				parts[p1] = arr[i] + parts[p1];
				if (arr[i] == 1)
					count++;
				if (count != ones / 3) continue;
				if (p2 >= 0)
					res[p2] = p2 == 0 ? i - 1 : i;
				p2--;
				p1--;
				count = 0;
			}
			var index = parts[^1].Length - 1;
			while (index >= 0 && parts[^1][index] == '0')
			{
				index--;
				countZero++;
			}
			for (int i = 0; i < parts.Length - 1; i++)
			{
				index = parts[i].Length - 1;
				count = 0;
				int len = parts[i].Length;
				while (index >= 0 && parts[i][index] == '0')
				{
					index--;
					count++;
				}
				parts[i] = parts[i].Substring(0, index + 1 + Math.Min(countZero, count));
				res[i] -= len - parts[i].Length;
			}
			if (parts[0] == parts[1] && parts[0] == parts[2])
				return res;
			return new[] {-1, -1};
		}
	}
}
