using System;
using System.Linq;

namespace FindTheStudentThatWillReplaceTheChalk
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] chalk = {3, 4, 1, 2, 1, 2, 3, 3};
			int k = 41;
			Console.WriteLine(chalkReplacer(chalk, k));
		}
		public static int chalkReplacer(int[] chalk, int k)
		{
			long sum = 0;
			foreach (var c in chalk)
				sum += c;
			var left = k % sum;
			int index = 0;
			while (index < chalk.Length && left - chalk[index] >= 0)
				left -= chalk[index++];
			return index;
		}
	}
}
