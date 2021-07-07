using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumWindowSubstring
{
	class Program
	{
		static void Main(string[] args)
		{
			//          012345
			string s = "aasagh", t = "asag";
			Console.WriteLine(MinWindow(s, t));
		}
		public static string MinWindow(string s, string t)
		{
			int start = 0, len = int.MaxValue;
			var lettersT = t.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
			var lettersS = new Dictionary<char, int>();
			int li = 0, hi = 0;
			while (hi < s.Length)
			{
				if (lettersT.ContainsKey(s[hi]))
				{
					if (!lettersS.ContainsKey(s[hi]))
						lettersS[s[hi]] = 0;
					lettersS[s[hi]]++;
				}
				while (lettersS.Count == lettersT.Count && lettersT.All(x => lettersS[x.Key] >= x.Value))
				{
					if (hi - li + 1 < len)
					{
						start = li;
						len = hi - li + 1;
					}
					if (lettersS.ContainsKey(s[li]))
						lettersS[s[li]]--;
					li++;
				}
				hi++;
			}
			return len == int.MaxValue ? "" : s.Substring(start, len);
		}
	}
}
