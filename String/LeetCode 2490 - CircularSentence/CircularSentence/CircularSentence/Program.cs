using System;

namespace CircularSentence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[^1])
                return false;
            var words = sentence.Split(' ');
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i - 1][^1] != words[i][0])
                    return false;
            }
            return true;
        }
    }
}
