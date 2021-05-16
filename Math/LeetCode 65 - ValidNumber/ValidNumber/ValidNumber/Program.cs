using System;

namespace ValidNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "-123.456e789";
			Console.WriteLine(IsNumber(s));
		}
		public static bool IsNumber(string s)
		{
			if (s.Length == 1) return char.IsDigit(s[0]);
			int countDot = 0, countE = 0, countNum = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (char.IsDigit(s[i])) countNum++;
				else if (s[i] != 'e' && s[i] != 'E' && char.IsLetter(s[i]))
					return false;
				else if (s[i] == 'e' || s[i] == 'E')
				{
					countE++;
					if (i == s.Length - 1 || i == 0 || countNum == 0)
						return false;
				}
				else if (s[i] == '.')
				{
					countDot++;
					if (countE != 0) return false;
				}
				else if ((s[i] == '+' || s[i] == '-') && (i != 0 && s[i - 1] != 'e' && s[i - 1] != 'E' || i == s.Length - 1))
					return false;
				if (countE > 1 || countDot > 1)
					return false;
			}
			return countNum > 0;
		}
	}
}
