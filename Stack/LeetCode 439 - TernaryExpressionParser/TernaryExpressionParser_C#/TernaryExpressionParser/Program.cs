using System;
using System.Collections.Generic;

namespace TernaryExpressionParser
{
	class Program
	{
		static void Main(string[] args)
		{
			var expression = "F?1:T?4:5";
			Console.WriteLine(ParseTernary(expression));
		}
		public static string ParseTernary(string expression)
		{
			var count = 0;
			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '?') count++;
				else if (expression[i] == ':') count--;
				if (count == 0 && expression[i] == ':')
					return expression[0] == 'T' ? ParseTernary(expression.Substring(2, i - 2)) : ParseTernary(expression.Substring(i + 1));
			}
			return expression;
		}
	}
}
