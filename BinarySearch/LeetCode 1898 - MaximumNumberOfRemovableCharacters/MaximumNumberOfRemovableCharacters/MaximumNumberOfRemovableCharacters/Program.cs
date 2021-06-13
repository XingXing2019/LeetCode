using System;
using System.Text;

namespace MaximumNumberOfRemovableCharacters
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "qobftgcueho", p = "obue";
			int[] removable = { 5, 3, 0, 6, 4, 9, 10, 7, 2, 8 };
			Console.WriteLine(MaximumRemovals(s, p, removable));
		}
		public static int MaximumRemovals(string s, string p, int[] removable)
		{
			int li = 0, hi = removable.Length;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				var str = new StringBuilder();
				var deleted = new bool[s.Length];
				for (int i = 0; i < mid; i++)
					deleted[removable[i]] = true;
				for (int i = 0; i < s.Length; i++)
				{
					if (!deleted[i])
						str.Append(s[i]);
				}
				if (IsSubsequence(str.ToString(), p))
					li = mid + 1;
				else
					hi = mid - 1;
			}
			return hi;
		}

		private static bool IsSubsequence(string s, string p)
		{
			if (s.Length < p.Length) return false;
			int p1 = 0, p2 = 0;
			while (p1 < s.Length && p2 < p.Length)
			{
				if (s[p1] == p[p2])
					p2++;
				p1++;
			}
			return p2 == p.Length;
		}
	}
}
