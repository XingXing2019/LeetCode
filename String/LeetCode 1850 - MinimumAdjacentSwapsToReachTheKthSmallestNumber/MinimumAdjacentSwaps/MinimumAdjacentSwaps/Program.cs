using System;
using System.Linq;

namespace MinimumAdjacentSwaps
{
	class Program
	{
		static void Main(string[] args)
		{
			var num = "5489355142";
			int k = 4;
			Console.WriteLine(GetMinSwaps(num, k));
		}

		public static int GetMinSwaps(string num, int k)
		{
			var src = num.Select(x => x - '0').ToArray();
			var target = num.Select(x => x - '0').ToArray();
			for (int i = 0; i < k; i++)
				NextPermutation(target);
			return CountSteps(src, target);
		}
		public static void NextPermutation(int[] num)
		{
			for (int i = num.Length - 1; i >= 1; i--)
			{
				if (num[i] <= num[i - 1]) continue;
			 	Array.Reverse(num, i, num.Length - i);
				for (int j = i; j < num.Length; j++)
				{
					if (num[j] <= num[i - 1]) continue;
					int temp = num[i - 1];
					num[i - 1] = num[j];
					num[j] = temp;
					return;
				}
			}
		}

		public static int CountSteps(int[] src, int[] target)
		{
			int res = 0, p1 = 0, p2 = 0;
			while (p1 < src.Length)
			{
				while (src[p1] != target[p2])
					p1++;
				while (p1 != p2)
				{
					int temp = src[p1 - 1];
					src[p1 - 1] = src[p1];
					src[p1] = temp;
					p1--;
					res++;
				}
				p1++;
				p2++;
			}
			return res;
		}
	}
}
