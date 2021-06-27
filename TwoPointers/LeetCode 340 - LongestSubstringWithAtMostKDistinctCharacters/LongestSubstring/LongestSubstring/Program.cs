using System;

namespace LongestSubstring
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int LengthOfLongestSubstringKDistinct(string s, int k)
		{
			int li = 0, hi = 0, res = 0;
			var dict = new Dictionary<char, int>();
			while (hi < s.Length)
			{
				if (!dict.ContainsKey(s[hi]))
					dict[s[hi]] = 0;
				dict[s[hi]]++;
				if (dict.Count <= k)
					res = Math.Max(res, hi - li + 1);
				else
				{
					while (dict.Count > k)
					{
						dict[s[li]]--;
						if (dict[s[li]] == 0)
							dict.Remove(s[li]);
						li++;
					}
				}
				hi++;
			}
			return res;
		}
    }
}
