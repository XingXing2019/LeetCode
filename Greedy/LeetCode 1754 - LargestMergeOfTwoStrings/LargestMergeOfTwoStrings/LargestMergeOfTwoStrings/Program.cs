using System;
using System.Text;

namespace LargestMergeOfTwoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string LargestMerge(string word1, string word2)
        {
            var res = new StringBuilder();
            int p1 = 0, p2 = 0;
            while (p1 < word1.Length && p2 < word2.Length)
            {
                if (word1[p1] > word2[p2])
                    res.Append(word1[p1++]);
                else if (word1[p1] < word2[p2])
                    res.Append(word2[p2++]);
                else if (word1.Substring(p1).CompareTo(word2.Substring(p2)) > 0)
                    res.Append(word1[p1++]);
                else
                    res.Append(word2[p2++]);
            }
            while (p1 < word1.Length)
                res.Append(word1[p1++]);
            while (p2 < word2.Length)
                res.Append(word2[p2++]);
            return res.ToString();
        }
    }
}
