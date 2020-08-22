using System;
using System.Collections.Generic;
using System.Text;

namespace StringsDifferByOneCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dict = { "abcd", "cccc", "abyd", "abab" };
            Console.WriteLine(DifferByOne(dict));
        }
        static bool DifferByOne_HashSet(string[] dict)
        {
            var set = new HashSet<string>();
            foreach (var word in dict)
            {
                var str = new StringBuilder(word);
                for (int i = 0; i < str.Length; i++)
                {
                    var letter = str[i];
                    str[i] = '*';
                    if (!set.Add(str.ToString()))
                        return true;
                    str[i] = letter;
                }
            }
            return false;
        }
        static bool DifferByOne(string[] dict)
        {
            for (int i = 0; i < dict.Length; i++)
            {
                var word1 = dict[i];
                for (int j = i + 1; j < dict.Length; j++)
                {
                    var word2 = dict[j];
                    int count = 0;
                    for (int k = 0; k < word1.Length; k++)
                    {
                        if (word1[k] != word2[k])
                            count++;
                        if(count > 1) break;
                    }
                    if (count == 1) return true;
                }
            }
            return false;
        }
    }
}
