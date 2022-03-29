using System;
using System.Collections.Generic;

namespace MaximizeTheConfusionOfAnExam
{
	class Program
	{
		static void Main(string[] args)
		{
			var answerKey = "TTFTTFTT";
			int k = 1;
			Console.WriteLine(MaxConsecutiveAnswers(answerKey, k));
		}

		public static int MaxConsecutiveAnswers(string answerKey, int k)
		{
			int res = 0, li = 0, hi = 0;
			var letters = new Dictionary<char, int> { { 'T', 0 }, { 'F', 0 } };
			letters[answerKey[0]]++;
			while (hi < answerKey.Length)
			{
				int maxNum = Math.Max(letters['T'], letters['F']);
				if (maxNum + k >= hi - li + 1)
				{
					if (++hi < answerKey.Length)
						letters[answerKey[hi]]++;
				}
				else
					letters[answerKey[li++]]--;
				res = Math.Max(res, hi - li);
			}
			return res;
		}
	}
}
