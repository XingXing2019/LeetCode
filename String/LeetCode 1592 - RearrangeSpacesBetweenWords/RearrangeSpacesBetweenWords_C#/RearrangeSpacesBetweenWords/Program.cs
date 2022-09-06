using System;
using System.Collections.Generic;

namespace RearrangeSpacesBetweenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string ReorderSpaces(string text)
        {
            var words = new List<string>();
            var word = "";
            var count = 0;
            foreach (var character in text)
            {
                if (character == ' ')
                {
                    count++;
                    if (word != "")
                    {
                        words.Add(word);
                        word = "";
                    }
                }
                else
                    word += character;
            }
            if(word != "")
                words.Add(word);
            string spaces = "", left = "";
            if (words.Count == 1)
            {
                for (int i = 0; i < count; i++)
                    left += ' ';
            }
            else
            {
                for (int i = 0; i < count / (words.Count - 1); i++)
                    spaces += ' ';
                for (int i = 0; i < count % (words.Count - 1); i++)
                    left += ' ';
            }
            return string.Join(spaces, words) + left;
        }
    }
}
