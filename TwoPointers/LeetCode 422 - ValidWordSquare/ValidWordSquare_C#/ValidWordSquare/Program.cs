using System;
using System.Collections.Generic;

namespace ValidWordSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = {"ball", "asee", "let", "lep"};
            Console.WriteLine(ValidWordSquare(words));
        }
        static bool ValidWordSquare(IList<string> words)
        {
            if (words.Count != words[0].Length) return false;
            for (int r = 0; r < words.Count; r++)
            {
                for (int c = 0; c < words[r].Length; c++)
                {
                    if (c >= words.Count || r >= words[c].Length || words[r][c] != words[c][r])
                        return false;
                }
            }
            return true;
        }
    }
}
