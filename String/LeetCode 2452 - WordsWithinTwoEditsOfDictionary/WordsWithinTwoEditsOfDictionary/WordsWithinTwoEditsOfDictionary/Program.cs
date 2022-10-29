using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsWithinTwoEditsOfDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] queries ={"word","note","ants","wood"};
            string[] dictionary = { "wood", "joke", "moat" };
            Console.WriteLine(TwoEditWords(queries, dictionary));
        }

        public static IList<string> TwoEditWords(string[] queries, string[] dictionary)
        {
            var res = new List<string>();
            foreach (var query in queries)
            {
                foreach (var word in dictionary)
                {
                    if (!IsValid(query, word)) continue;
                    res.Add(query);
                    break;
                }
            }
            return res;
        }

        public static bool IsValid(string query, string word)
        {
            var count = 0;
            for (int i = 0; i < query.Length; i++)
            {
                if (query[i] != word[i])
                    count++;
                if (count > 2)
                    return false;
            }
            return true;
        }
    }
}
