using System;
using System.Linq;

namespace ShortestCompletingWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string ShortestCompletingWord(string licensePlate, string[] words)
        {
            var res = words.First(word => IsComplete(licensePlate, word));
            foreach (var word in words)
                if (IsComplete(licensePlate, word) && word.Length < res.Length)
                    res = word;
            return res;
        }
        static bool IsComplete(string licensePlate, string word)
        {
            var record = new int[26];
            for (int i = 0; i < licensePlate.Length; i++)
                if (char.IsLetter(licensePlate[i]))
                    record[char.ToLower(licensePlate[i]) - 'a']++;
            for (int i = 0; i < word.Length; i++)
                record[word[i] - 'a']--;
            return record.All(letter => letter <= 0);
        }
    }
}
