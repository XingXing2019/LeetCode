using System;
using System.Linq;

namespace NumberOfValidWordsInASentence
{
	class Program
	{
		static void Main(string[] args)
		{
			var sentence = "cat and  dog";
			Console.WriteLine(CountValidWords(sentence));
		}

		public static int CountValidWords(string sentence)
		{
			var words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			return words.Count(IsValid);
		}

		public static bool IsValid(string word)
		{
			int countDigit = word.Count(char.IsDigit), countP = word.Count(x => x == ',' || x == '.' || x == '!'), countH = word.Count(x => x == '-');
			if (countDigit > 0 || countH > 1 || countP > 1)
				return false;
			if (countH == 1)
			{
				var index = word.IndexOf('-');
				if (index == 0 || index == word.Length - 1 || !char.IsLetter(word[index - 1]) || !char.IsLetter(word[index + 1]))
					return false;
			}
			if (countP == 1)
			{
				int index1 = word.IndexOf(','), index2 = word.IndexOf('.'), index3 = word.IndexOf('!');
				if (index1 != -1 && index1 != word.Length - 1 || index2 != -1 && index2 != word.Length - 1 || index3 != -1 && index3 != word.Length - 1)
					return false;
			}
			return true;
		}
	}
}
