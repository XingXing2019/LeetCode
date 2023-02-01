using System;
using System.Collections.Generic;

namespace SentenceSimilarity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool AreSentencesSimilar(string[] words1, string[] words2, IList<IList<string>> pairs)
        {
            if (words1.Length != words2.Length) return false;
            var wordPairs = new HashSet<string>();
            foreach (var pair in pairs)
            {
                wordPairs.Add(pair[0] + pair[1]);
                wordPairs.Add(pair[1] + pair[0]);
            }
            for (int i = 0; i < words1.Length; i++)
            {
                if(words1[i] == words2[i]) 
                    continue;
                if(!wordPairs.Contains(words1[i] + words2[i]) && !wordPairs.Contains(words2[i] + words1[i]))
                    return false;
            }
            return true;
        }
    }
}
