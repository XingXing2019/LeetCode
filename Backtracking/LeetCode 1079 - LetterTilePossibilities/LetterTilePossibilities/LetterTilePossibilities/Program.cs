using System;
using System.Collections.Generic;
using System.Text;

namespace LetterTilePossibilities
{
    class Program
    {
        static void Main(string[] args)
        {
            string tiles = "AAB";
            Console.WriteLine(NumTilePossibilities(tiles));
        }
        static int NumTilePossibilities(string tiles)
        {
            var letters = new int[26];
            foreach (var c in tiles)
                letters[c - 'A']++;
            return DFS(letters);
        }

        static int DFS(int[] letters)
        {
            int res = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == 0)
                    continue;
                res++;
                letters[i]--;
                res += DFS(letters);
                letters[i]++;
            }
            return res;
        }
    }
}
