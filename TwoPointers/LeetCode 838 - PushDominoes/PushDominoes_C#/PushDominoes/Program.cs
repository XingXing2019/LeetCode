using System;
using System.Text;

namespace PushDominoes
{
	class Program
	{
		static void Main(string[] args)
		{
			string dominoes = "R...L..L..";
			Console.WriteLine(PushDominoes(dominoes));
		}
		public static string PushDominoes(string dominoes)
		{
			var str = new StringBuilder(dominoes);
			int l = -1, r = -1;
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == '.') continue;
				if (str[i] == 'L')
				{
					l = i;
					int p1 = r, p2 = l;
					while (p2 >= 0 && p1 < p2)
					{
						if (p1 >= 0 && str[p1] != 'L')
							str[p1++] = 'R';
						if (p2 < str.Length)
							str[p2--] = 'L';
					}
				}
				else if (r != -1 && str[r] == 'R')
				{
					while (r != i)
						str[r++] = 'R';
				}
				r = i;
			}
			if (l >= r) return str.ToString();
			while (r < str.Length)
				str[r++] = 'R';
			return str.ToString();
		}
	}
}
