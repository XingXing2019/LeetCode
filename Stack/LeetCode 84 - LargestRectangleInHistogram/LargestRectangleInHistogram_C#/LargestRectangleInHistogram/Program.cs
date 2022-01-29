using System;
using System.Collections.Generic;

namespace LargestRectangleInHistogram
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] heights = { 2, 1, 5, 6, 2, 3 };
			Console.WriteLine(LargestRectangleArea(heights));
		}
		public static int LargestRectangleArea(int[] heights)
		{
			var stack = new Stack<int>();
			stack.Push(-1);
			int res = 0;
			for (int i = 0; i < heights.Length; i++)
			{
				while (stack.Count != 0 && heights[i] < (stack.Peek() == -1 ? -1 : heights[stack.Peek()]))
				{
					int index = stack.Pop();
					var len = i - index + index - stack.Peek() - 1;
					res = Math.Max(res, len * heights[index]);
				}
				stack.Push(i);
			}
			while (stack.Count != 1)
			{
				var index = stack.Pop();
				int len = heights.Length - index + index - stack.Peek() - 1;
				res = Math.Max(res, len * heights[index]);
			}
			return res;
		}
	}
}
