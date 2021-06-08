using System;
using System.Collections.Generic;

namespace EncodeAndDecodeStrings
{
	class Program
	{
		static void Main(string[] args)
		{
			var d = '\u0000';
			Console.WriteLine(d);
		}
	}

	public class Codec
	{
		private char delimiter = '\u0000';
		public string Encode(IList<string> strs)
		{
			return string.Join(delimiter, strs);
		}

		// Decodes a single string to a list of strings.
		public IList<string> Decode(string s)
		{
			return s.Split(delimiter);
		}
	}
}
