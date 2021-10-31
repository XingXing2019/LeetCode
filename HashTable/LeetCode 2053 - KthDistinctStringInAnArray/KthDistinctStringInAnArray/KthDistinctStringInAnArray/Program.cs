using System;
using System.Linq;

namespace KthDistinctStringInAnArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public string KthDistinct(string[] arr, int k)
		{
			var distinct = arr.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).ToList();
			return distinct.Count >= k ? distinct[k - 1] : "";
		}
	}
}
