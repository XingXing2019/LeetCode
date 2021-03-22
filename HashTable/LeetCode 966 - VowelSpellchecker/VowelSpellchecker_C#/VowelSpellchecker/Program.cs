using System;
using System.Collections.Generic;

namespace VowelSpellchecker
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            HashSet<string> wordPerf = new HashSet<string>();
            Dictionary<string, string> capError = new Dictionary<string, string>();
            Dictionary<string, string> vowelError = new Dictionary<string, string>();
            string[] result = new string[queries.Length];
            foreach (string word in wordlist)
            {
                wordPerf.Add(word);
                string lower = GetLower(word);
                string vowelsRemoved = GetRemoveVowel(lower);
                if (capError.ContainsKey(lower) == false)
                    capError[lower] = word;
                if (vowelError.ContainsKey(vowelsRemoved) == false)
                    vowelError[vowelsRemoved] = word;
            }

            for (int i = 0; i < queries.Length; i++)
            {
                string qry = queries[i];
                string lower = GetLower(qry);
                string vRemoved = GetRemoveVowel(lower);
                string output = string.Empty;
                if (wordPerf.Contains(qry))
                    output = qry;
                else if (capError.ContainsKey(lower))
                    output = capError[lower];
                else if (vowelError.ContainsKey(vRemoved))
                    output = vowelError[vRemoved];
                result[i] = output;
            }
            return result;
        }
        private string GetLower(string s)
        {
            char[] letters = s.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
                letters[i] = char.ToLower(letters[i]);
            return new string(letters);
        }

        private string GetRemoveVowel(string s)
        {
            char[] letters = s.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
                if (IsVowel(letters[i]))
                    letters[i] = '*';
            return new string(letters);
        }

        private bool IsVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }
    }
}
