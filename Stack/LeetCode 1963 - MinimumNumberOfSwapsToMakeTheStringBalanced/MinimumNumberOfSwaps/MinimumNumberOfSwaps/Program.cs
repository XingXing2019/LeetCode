using System;
using System.Collections.Generic;

namespace MinimumNumberOfSwaps
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = "[]]]]][[[[";
			Console.WriteLine(MinSwaps(s));
		}
		public static int MinSwaps(string s)
		{
			var stack = new Stack<char>();
			foreach (var c in s)
			{
				if (stack.Count != 0 && c == ']' && stack.Peek() == '[')
					stack.Pop();
				else
					stack.Push(c);
			}
			return stack.Count / 4 + stack.Count % 4 / 2;
		}
	}
}
