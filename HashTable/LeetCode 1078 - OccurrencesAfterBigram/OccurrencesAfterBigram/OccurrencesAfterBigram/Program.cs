using System;
using System.Collections.Generic;

namespace OccurrencesAfterBigram
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "alice is a good girl she is a good student";
            string first = "a";
            string second = "good";
            Console.WriteLine(FindOcurrences(text, first, second));
        }
        static string[] FindOcurrences(string text, string first, string second)
        {
            var words = text.Split(" ");
            var res = new List<string>();
            if (words.Length < 3)
                return res.ToArray();
            for (int i = 0; i < words.Length - 2; i++)
            {
                if(words[i] == first && words[i + 1] == second)
                    res.Add(words[i + 2]);
            }
            return res.ToArray();
        }
    }
}
