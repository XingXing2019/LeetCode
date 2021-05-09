using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructTargetArrayWithMultipleSums
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] target = {3, 5, 9};
			Console.WriteLine(IsPossible(target));
		}
		public static bool IsPossible(int[] target)
		{
			long sum = 0;
			var maxHeap = new List<long>();
			foreach (var num in target)
			{
				sum += num;
				maxHeap.Add(num);
			}
			maxHeap.Sort();
			sum -= maxHeap[^1];
			while (maxHeap[^1] != 1)
			{
				long max = maxHeap[^1];
				maxHeap.RemoveAt(maxHeap.Count - 1);
				if (sum == 0 || max <= sum) return false;
				max %= sum;
				if (max < maxHeap[^1])
					sum = sum - maxHeap[^1] + max;
				var index = maxHeap.BinarySearch(max);
				if (index < 0) index = ~index;
				maxHeap.Insert(index, max);
			}
			return true;
		}
	}
}
