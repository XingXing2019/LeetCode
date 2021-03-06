using System;
using System.Collections.Generic;

namespace ShortEncodingOfWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinimumLengthEncoding(string[] words)
        {
            var remains = new HashSet<string>(words);
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length - 1; i++)
                {
                    var tempWord = word.Substring(word.Length - 1 - i);
                    if (remains.Contains(tempWord))
                        remains.Remove(tempWord);
                }
            }
            int res = remains.Count;
            foreach (var word in remains)
                res += word.Length;
            return res;
        }
    }
}
