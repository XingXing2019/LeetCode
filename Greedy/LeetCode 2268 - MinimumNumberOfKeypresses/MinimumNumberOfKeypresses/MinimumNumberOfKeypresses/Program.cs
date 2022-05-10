using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumNumberOfKeypresses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumKeypresses(string s)
        {
            var freq = s.GroupBy(x => x).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
            var pad = new List<char>[9];
            for (int i = 0; i < pad.Length; i++)
                pad[i] = new List<char>();
            int index = 0, res = 0;
            foreach (var letter in freq.Keys)
            {
                pad[index % 9].Add(letter);
                index++;
            }
            foreach (var letters in pad)
            {
                for (int i = 0; i < letters.Count; i++)
                {
                    var letter = letters[i];
                    res += (i + 1) * freq[letter];
                }   
            }
            return res;
        }
    }
}
