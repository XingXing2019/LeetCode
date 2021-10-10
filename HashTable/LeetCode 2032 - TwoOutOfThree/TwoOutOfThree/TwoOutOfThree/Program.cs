using System;
using System.Collections.Generic;

namespace TwoOutOfThree
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
		{
			HashSet<int> n1 = new HashSet<int>(nums1), n2 = new HashSet<int>(nums2), n3 = new HashSet<int>(nums3);
			var freq = new int[101];
			foreach (var num in n1)
				freq[num]++;
			foreach (var num in n2)
				freq[num]++;
			foreach (var num in n3)
				freq[num]++;
			var res = new List<int>();
			for (int i = 0; i < freq.Length; i++)
			{
				if(freq[i] > 1)
					res.Add(i);
			}
			return res;
		}
	}
}
