using System;

namespace CheckIfStringIsDecomposable
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "00011111222";
			Console.WriteLine(IsDecomposable(s));
		}

		public static bool IsDecomposable(string s)
		{
			int count = 0, chance = 1, record = s[0] - '0';
			foreach (var l in s)
			{
				if (l - '0' == record)
					count++;
				else
				{
					if (count % 3 != 0 && count % 3 != 2)
						return false;
					if (count % 3 == 2)
						chance--;
					record = l - '0';
					count = 1;
				}
			}
			return chance == 0 && count % 3 == 0 || chance == 1 && count % 3 == 2;
		}
	}
}
