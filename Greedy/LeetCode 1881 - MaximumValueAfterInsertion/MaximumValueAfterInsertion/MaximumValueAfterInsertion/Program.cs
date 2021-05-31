using System;
using System.ComponentModel;

namespace MaximumValueAfterInsertion
{
	class Program
	{
		static void Main(string[] args)
		{
			string n = "-13";
			int x = 3;
			Console.WriteLine(MaxValue(n, x));
		}
		public static string MaxValue(string n, int x)
		{
			var isNeg = n[0] == '-';
			int index = isNeg ? 1 : 0;
			while (index < n.Length && (isNeg ? n[index] - '0' <= x : n[index] - '0' >= x))
				index++;
			return n.Substring(0, index) + x + n.Substring(index);
		}
	}
}
