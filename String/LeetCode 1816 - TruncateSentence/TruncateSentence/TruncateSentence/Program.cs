using System;

namespace TruncateSentence
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string TruncateSentence(string s, int k)
		{
			var words = s.Split(' ');
			var res = "";
			for (int i = 0; i < k; i++)
				res += i == k - 1 ? words[i] : $"{words[i]} ";
			return res;
		}
	}
}
