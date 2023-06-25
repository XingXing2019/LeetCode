using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMaximumNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "cd", "ac", "dc", "ca", "zz" };
            Console.WriteLine(MaximumNumberOfStringPairs(words));
        }

        public static int MaximumNumberOfStringPairs(string[] words)
        {
            var set = new HashSet<string>();
            foreach (var word in words)
            {
                var reversed = Reverse(word);
                if (set.Contains(reversed))
                    set.Remove(reversed);
                else
                    set.Add(word);
            }
            return (words.Length - set.Count) / 2;
        }

        public static string Reverse(string word)
        {
            return string.Join("", word.Reverse());
        }
    }
}
