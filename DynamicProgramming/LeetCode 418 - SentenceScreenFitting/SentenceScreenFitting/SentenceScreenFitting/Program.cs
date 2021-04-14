using System;

namespace SentenceScreenFitting
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] sentence = {"hello", "world"};
			int rows = 2, cols = 11;
			Console.WriteLine(WordsTyping_SearchSentence(sentence, rows, cols));
		}
		public int WordsTyping_SearchWord(string[] sentence, int rows, int cols)
		{
			int r = 0, c = 0, index = 0, res = 0;
			while (r < rows)
			{
				var word = sentence[index];
				if (cols - c >= word.Length)
				{
					c += word.Length + 1;
					index++;
					if (index >= sentence.Length)
					{
						index = 0;
						res++;
					}
					if (c < cols) continue;
					c = 0;
					r++;
				}
				else
				{
					c = 0;
					r++;
				}
			}
			return res;
		}

		public static int WordsTyping_SearchSentence(string[] sentence, int rows, int cols)
		{
			int start = 0;
			var str = string.Join(' ', sentence);
			str += " ";
			for (int i = 0; i < rows; i++)
			{
				start += cols;
				if (str[start % str.Length] == ' ')
				{
					start++;
					continue;
				}
				while (start > 0 && str[start % str.Length] != ' ')
					start--;
				start++;
			}
			return start / str.Length;
		}
	}
}
