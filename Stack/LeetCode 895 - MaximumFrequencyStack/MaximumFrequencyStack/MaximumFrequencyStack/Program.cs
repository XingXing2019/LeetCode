using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumFrequencyStack
{
	class Program
	{
		static void Main(string[] args)
		{
			var stack = new FreqStack();
			stack.Push(4);
			stack.Push(0);
			stack.Push(9);
			stack.Push(3);
			stack.Push(4);
			stack.Push(2);
			stack.Pop();
			stack.Push(6);
			stack.Pop();
			stack.Push(1);
			stack.Pop();
			stack.Push(1);
			stack.Pop();
			stack.Push(4);
			stack.Pop();
			stack.Pop();
			stack.Pop();
			stack.Pop();
			stack.Pop();
			stack.Pop();
		}
	}
	public class FreqStack
	{
		private Dictionary<int, int> freq;
		private Dictionary<int, Stack<int>> groups;
		private int maxFreq;
		public FreqStack()
		{
			freq = new Dictionary<int, int>();
			groups = new Dictionary<int, Stack<int>>();
		}

		public void Push(int x)
		{
			if (!freq.ContainsKey(x))
				freq[x] = 0;
			freq[x]++;
			maxFreq = Math.Max(maxFreq, freq[x]);
			if (!groups.ContainsKey(freq[x]))
				groups[freq[x]] = new Stack<int>();
			groups[freq[x]].Push(x);
		}

		public int Pop()
		{
			int res = groups[maxFreq].Pop();
			if (groups[maxFreq].Count == 0)
				maxFreq--;
			freq[res]--;
			return res;
		}
	}
}
