using System;

namespace BoldWordsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = {"ab", "bc"};
            string S = "aabcd";
            Console.WriteLine(BoldWords(words, S));
        }
        static string BoldWords(string[] words, string S)
        {
            var isBold = new bool[S.Length + 2];
            var letters = new string[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                letters[i] = S[i].ToString();
                foreach (var word in words)
                {
                    if(S.Length - i < word.Length) continue;
                    if (S.Substring(i, word.Length) == word)
                    {
                        for (int j = 0; j < word.Length; j++)
                            isBold[i + j + 1] = true;
                    }
                }
            }
            var res = "";
            for (int i = 0; i < letters.Length; i++)
            {
                if (isBold[i + 1] && !isBold[i])
                    letters[i] = "<b>" + letters[i];
                if (isBold[i + 1] && !isBold[i + 2])
                    letters[i] += "</b>";
                res += letters[i];
            }
            return res;
        }
    }
}
