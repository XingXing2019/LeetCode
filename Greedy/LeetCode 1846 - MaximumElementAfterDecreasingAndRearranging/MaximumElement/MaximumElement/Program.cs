using System;

namespace MaximumElement
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
		{
			Array.Sort(arr);
			int res = 1;
			arr[0] = 1;
			for (int i = 1; i < arr.Length; i++)
			{
				arr[i] = Math.Min(arr[i - 1] + 1, arr[i]);
				res = Math.Max(res, arr[i]);
			}
			return res;
		}
	}
}
