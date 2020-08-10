using System;
using System.Collections.Generic;
using System.Linq;

namespace BeforeAndAfterPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<string> BeforeAndAfterPuzzles(string[] phrases)
        {
            var set = new HashSet<string>();
            var exceptFirst = new string[phrases.Length];
            var exceptLast = new string[phrases.Length];
            var splitWords = new string[phrases.Length][];
            for (int i = 0; i < phrases.Length; i++)
            {
                splitWords[i] = phrases[i].Split(" ");
                exceptFirst[i] = splitWords[i].Length == 1 ? splitWords[i][0] : string.Join(' ', splitWords[i]);
                exceptLast[i] = splitWords[i].Length == 1 ? "" : string.Join(' ', splitWords[i][..^1]);
            }
            for (int i = 0; i < phrases.Length; i++)
            {
                for (int j = 0; j < phrases.Length; j++)
                {
                    if(i == j) continue;
                    if (splitWords[i][^1] == splitWords[j][0])
                        set.Add((exceptLast[i] + " " + exceptFirst[j]).Trim());
                }
            }
            return set.OrderBy(x => x).ToList();
        }

    }
}
