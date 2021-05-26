using System;

namespace SumOfBeautyOfAllSubstrings
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "aabcbaa";
			Console.WriteLine(BeautySum(s));
		}
		public static int BeautySum(string s)
		{
			var record = new int[s.Length][];
			record[0] = new int[26];
			record[0][s[0] - 'a']++;
			for (int i = 1; i < s.Length; i++)
			{
				record[i] = new int[26];
				for (int j = 0; j < 26; j++)
					record[i][j] = record[i - 1][j];
				record[i][s[i] - 'a']++;
			}
			int res = 0;
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = i + 1; j < s.Length; j++)
				{
					int max = 0, min = int.MaxValue;
					var temp = i == 0 ? new int[26] : record[i - 1];
					for (int k = 0; k < 26; k++)
					{
						if (record[j][k] == temp[k]) continue;
						max = Math.Max(max, record[j][k] - temp[k]);
						min = Math.Min(min, record[j][k] - temp[k]);
					}
					res += max - min;
				}
			}
			return res;
		}
	}
}
