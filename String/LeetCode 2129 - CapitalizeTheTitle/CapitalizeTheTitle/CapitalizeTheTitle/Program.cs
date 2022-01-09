using System;

namespace CapitalizeTheTitle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CapitalizeTitle(string title)
        {
            var words = title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (word.Length < 3)
                    words[i] = word.ToLower();
                else
                    words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();
            }
            return string.Join(' ', words);
        }
    }
}
