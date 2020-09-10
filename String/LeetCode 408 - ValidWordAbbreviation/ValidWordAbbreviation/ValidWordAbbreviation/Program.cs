using System;
using System.Collections.Generic;

namespace ValidWordAbbreviation
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "a", abbr = "01";
            Console.WriteLine(ValidWordAbbreviation(word, abbr));
        }
        static bool ValidWordAbbreviation(string word, string abbr)
        {
            var dict = new Dictionary<char, List<int>>();
            string num = "";
            int index = -1;
            foreach (var character in abbr)
            {
                if (char.IsLetter(character))
                {
                    if (num.StartsWith('0'))
                        return false;
                    index += num == "" ? 1 : int.Parse(num) + 1;
                    if (!dict.ContainsKey(character))
                        dict[character] = new List<int>();
                    dict[character].Add(index);
                    num = "";
                }
                else
                    num += character;
            }
            if (num.StartsWith('0'))
                return false;
            index += num == "" ? 1 : int.Parse(num) + 1;
            if (index != word.Length)
                return false;
            foreach (var kv in dict)
            {
                foreach (var i in kv.Value)
                {
                    if (word[i] != kv.Key)
                        return false;
                }
            }
            return true;
        }
    }
}
