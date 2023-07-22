using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortVowelsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string SortVowels(string s)
        {
            var vowels = s.Where(x => IsVowels(x)).OrderBy(x => x).ToList();
            var index = 0;
            var res = new StringBuilder();
            foreach (var l in s)
            {
                if (!IsVowels(l))
                    res.Append(l);
                else
                    res.Append(vowels[index++]);
            }
            return res.ToString();
        }

        public bool IsVowels(char l)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return vowels.Contains(l);
        }
    }
}
