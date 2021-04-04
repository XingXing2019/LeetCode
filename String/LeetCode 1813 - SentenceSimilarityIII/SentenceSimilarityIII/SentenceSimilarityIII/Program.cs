using System;

namespace SentenceSimilarityIII
{
	class Program
	{
		static void Main(string[] args)
		{
			string sentence1 = "of", sentence2 = "A lot of words";
			Console.WriteLine(AreSentencesSimilar(sentence1, sentence2));
		}
		public static bool AreSentencesSimilar(string sentence1, string sentence2)
		{
			var words1 = sentence1.Split(' ');
			var words2 = sentence2.Split(' ');
			return words1.Length > words2.Length ? Compare(words1, words2) : Compare(words2, words1);
		}

		public static bool Compare(string[] words1, string[] words2)
		{
			int p1 = 0, p2 = 0, count = 0;
			bool insert = false;
			while (p1 < words1.Length && p2 < words2.Length)
			{
				if (words1[p1] != words2[p2])
					insert = true;
				else
				{
					p2++;
					if (insert)
					{
						count++;
						insert = false;
					}
				}
				p1++;
			}
			if (insert) count++;
			return count == 0 || count == 1 && p1 == words1.Length && p2 == words2.Length;
		}
	}
}
