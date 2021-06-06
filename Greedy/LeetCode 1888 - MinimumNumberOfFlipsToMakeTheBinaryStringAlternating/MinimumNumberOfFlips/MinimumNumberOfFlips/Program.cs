using System;
using System.Text;

namespace MinimumNumberOfFlips
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "011";
			Console.WriteLine(MinFlips(s));
		}
		public static int MinFlips(string s)
		{
			int evenZero = 0, oddOne = 0, evenOne = 0, oddZero = 0;
			int li = 0, hi = s.Length, res = int.MaxValue;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '0')
				{
					if (i % 2 == 0) evenZero++;
					else oddZero++;
				}
				else
				{
					if (i % 2 == 0) evenOne++;
					else oddOne++;
				}
			}
			s += s;
			while (hi < s.Length)
			{
				res = Math.Min(res, Math.Min(evenZero + oddOne, evenOne + oddZero));
				if (s[li] == '1')
					evenOne--;
				else
					evenZero--;
				li++;
				Swap(ref oddZero, ref evenZero);
				Swap(ref oddOne, ref evenOne);
				if (s[hi] == '1')
				{
					if (s.Length / 2 % 2 == 0) oddOne++;
					else evenOne++;
				}
				else
				{
					if (s.Length / 2 % 2 == 0) oddZero++;
					else evenZero++;
				}
				hi++;
			}
			res = Math.Min(res, Math.Min(evenZero + oddOne, evenOne + oddZero));
			return res;
		}

		public static void Swap(ref int num1, ref int num2)
		{
			int temp = num1;
			num1 = num2;
			num2 = temp;
		}
	}
}
