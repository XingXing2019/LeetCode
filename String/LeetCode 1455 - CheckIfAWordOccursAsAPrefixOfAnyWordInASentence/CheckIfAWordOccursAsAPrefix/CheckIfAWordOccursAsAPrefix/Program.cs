using System;

namespace CheckIfAWordOccursAsAPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            var words = sentence.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i].Length < searchWord.Length)
                    continue;
                if (words[i].Substring(0, searchWord.Length) == searchWord)
                    return i + 1;
            }
            return -1;
        }
    }
}
