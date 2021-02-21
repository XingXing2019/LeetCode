using System;
using System.Text;

namespace MergeStringsAlternately
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string MergeAlternately(string word1, string word2)
        {
            var res = new StringBuilder();
            int p1 = 0, p2 = 0, count = 0;
            while (p1 < word1.Length && p2 < word2.Length)
            {
                res.Append(count % 2 == 0 ? word1[p1++] : word2[p2++]);
                count++;
            }
            while (p1 < word1.Length)
                res.Append(word1[p1++]);
            while (p2 < word2.Length)
                res.Append(word2[p2++]);
            return res.ToString();
        }
    }
}
