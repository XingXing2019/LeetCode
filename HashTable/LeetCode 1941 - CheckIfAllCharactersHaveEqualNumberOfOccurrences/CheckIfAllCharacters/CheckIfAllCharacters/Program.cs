using System;
using System.Linq;

namespace CheckIfAllCharacters
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool AreOccurrencesEqual(string s)
		{
			var dict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
			int count = dict.Max(x => x.Value);
			return dict.All(x => x.Value == count);
		}
	}
}
