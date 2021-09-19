using System;
using System.Linq;

namespace FinalValueOfVariable
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int FinalValueAfterOperations(string[] operations)
		{
			return operations.Sum(op => op.Contains("++") ? 1 : -1);
		}
	}
}
