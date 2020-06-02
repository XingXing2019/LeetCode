//创建CheckValid方法检查符合条件的单词。遍历words遇到符合条件的单词，则将其长度加入res。
using System;
using System.Linq;

namespace FindWordsThatCanBeFormedByCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountCharacters(string[] words, string chars)
        {
            var record = new int[26];
            for (int i = 0; i < chars.Length; i++)
                record[chars[i] - 'a']++;
            int res = 0;
            foreach (var word in words)
            {
                var letters = new int[26];
                Array.Copy(record, letters, 26);
                if (CheckValid(letters, word))
                    res += word.Length;
            }
            return res;
        }
        static bool CheckValid(int[] letters, string word)
        {
            for (int i = 0; i < word.Length; i++)
                letters[word[i] - 'a']--;
            return letters.All(letter => letter >= 0);
        }
    }
}
