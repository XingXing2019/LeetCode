using System;

namespace MaximumRepeatingSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = "ababc", word = "ababc";
            Console.WriteLine(MaxRepeating(sequence, word));
        }

        static int MaxRepeating(string sequence, string word)
        {
            var res = 0;
            for (int i = 0; i <= sequence.Length - word.Length; i++)
            {
                int len = 0;
                for (int j = 0; i + word.Length * j <= sequence.Length - word.Length; j++)
                {
                    if (sequence.Substring(i + j * word.Length, word.Length) == word)
                        len++;
                    else
                        break;
                }
                res = Math.Max(res, len);
            }
            return res;
        }
    }
}
