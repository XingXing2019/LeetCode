using System;
using System.Collections.Generic;

namespace RemoveOneElement
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 2, 3, 1, 2 };
			Console.WriteLine(CanBeIncreasing(nums));
		}
		public static bool CanBeIncreasing(int[] nums)
		{
			var stack = new Stack<int>();
			int count = 0;
			foreach (var num in nums)
			{
				if (stack.Count > 0 && num <= stack.Peek())
				{
					if (count == 1) return false;
					count++;
					int peek = stack.Pop();
					if (stack.Count > 0)
						stack.Push(num > stack.Peek() ? num : peek);
					else
						stack.Push(num);
				}
				else
					stack.Push(num);
			}
			return true;
		}
	}
}
