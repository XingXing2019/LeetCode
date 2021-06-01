using System;
using System.Linq;
using System.Collections.Generic;

namespace MinimumInsertions
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = ")))()((())))()((";
			Console.WriteLine(MinInsertions(s));
		}
		public static int MinInsertions(string s)
		{
			var stack = new Stack<char>();
			int left = 0, right = 0, res = 0;
			foreach (var l in s)
			{
				if (l == ')')
				{
					stack.Push(l);
					right++;
					if (right != 2) continue;
					for (int i = 0; i < right; i++)
						stack.Pop();
					if (stack.Count != 0 && stack.Peek() == '(')
						stack.Pop();
					else
						res++;
					right = 0;
				}
				else
				{
					if (right == 1)
					{
						res++;
						while (stack.Count != 0 && stack.Peek() != '(')
							stack.Pop();
						if (stack.Count != 0)
							stack.Pop();
						else
							res++;
						right = 0;
					}
					stack.Push(l);
				}
			}
			left = stack.Count(x => x == '(');
			right = stack.Count(x => x == ')');
			if (left != 0) res += left * 2 - right;
			else if (right != 0) res += 2;
			return res;
		}
	}
}
