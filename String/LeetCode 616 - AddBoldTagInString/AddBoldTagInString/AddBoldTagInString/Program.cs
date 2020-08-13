using System;

namespace AddBoldTagInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string AddBoldTag(string s, string[] dict)
        {
            var isBold = new bool[s.Length + 2];
            var letters = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                letters[i] = s[i].ToString();
                foreach (var word in dict)
                {
                    if(s.Length - i < word.Length) continue;
                    if (s.Substring(i, word.Length) == word)
                    {
                        for (int j = 0; j < word.Length; j++)
                            isBold[i + j + 1] = true;
                    }
                }
            }
            var res = "";
            for (int i = 0; i < s.Length; i++)
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
