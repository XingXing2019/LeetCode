using System;

namespace LongerContiguousSegmentsOfOnesThanZeros
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool CheckZeroOnes(string s)
		{
			if (s.Length == 1) return s[0] == '1';
			int li = 0, hi = 1;
			var digits = new int[2];
			digits[s[0] - '0']++;
			while (hi < s.Length)
			{
				if (s[hi] != s[hi - 1])
				{
					digits[s[hi - 1] - '0'] = Math.Max(digits[s[hi - 1] - '0'], hi - li);
					li = hi;
				}
				hi++;
			}
			digits[s[hi - 1] - '0'] = Math.Max(digits[s[hi - 1] - '0'], hi - li);
			return digits[1] > digits[0];
		}
	}
}
