using System;

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
			int[] src = new int[num.Length], target = new int[num.Length];
			for (int i = 0; i < num.Length; i++)
			{
				src[i] = num[i] - '0';
				target[i] = src[i];
			}
			for (int i = 0; i < k; i++)
				NextPermutation(target);
			return CountSteps(src, target);
		}

		public static void Swap(int[] num, int a, int b)
		{
			int temp = num[a];
			num[a] = num[b];
			num[b] = temp;
		}

		public static void Reverse(int[] num, int i)
		{
			int j = num.Length - 1;
			while (i < j)
			{
				int temp = num[i];
				num[i] = num[j];
				num[j] = temp;
				i++;
				j--;
			}
		}

		public static void NextPermutation(int[] num)
		{
			int len = num.Length;
			for (int i = len - 1; i >= 1; i--)
			{
				if (num[i] <= num[i - 1]) continue;
				Reverse(num, i);
				for (int j = i; j < len; j++)
				{
					if (num[j] <= num[i - 1]) continue;
					Swap(num, i - 1, j);
					return;
				}
			}
			Reverse(num, 0);
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
