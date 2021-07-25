using System;
using System.Text;

namespace LargestNumberAfterMutatingSubstring
{
	class Program
	{
		static void Main(string[] args)
		{
			var num = "214010";
			int[] change = {6, 7, 9, 7, 4, 0, 3, 4, 4, 7};
			Console.WriteLine(MaximumNumber(num, change));
		}
		public static string MaximumNumber(string num, int[] change)
		{
			var res = new StringBuilder(num);
			int index = 0;
			while (index < num.Length && change[res[index] - '0'] <= res[index] - '0')
				index++;
			while (index < num.Length && change[res[index] - '0'] >= res[index] - '0')
			{
				res[index] = (char)(change[res[index] - '0'] + '0');
				index++;
			}
			return res.ToString();
		}
	}
}
