using System;
using System.Collections.Generic;

namespace CountUnhappyFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[][] preferences = new int[][]
            {
                new[] {1, 3, 2},
                new[] {2, 3, 0},
                new[] {1, 3, 0},
                new[] {0, 2, 1},
            };
            int[][] pairs = new int[][]
            {
                new[] {0, 1},
                new[] {2, 3},
            };
            Console.WriteLine(UnhappyFriends(n, preferences, pairs));
        }
        static int UnhappyFriends(int n, int[][] preferences, int[][] pairs)
        {
            int res = 0;
            var people = new int[n];
            foreach (var pair in pairs)
            {
                people[pair[0]] = pair[1];
                people[pair[1]] = pair[0];
            }
            for (int i = 0; i < people.Length; i++)
            {
                var firstPersonUnhappy = false;
                for (int j = 0; j < preferences[i].Length; j++)
                {
                    var u = preferences[i][j];
                    if (u == people[i]) break;
                    if (Array.IndexOf(preferences[u], i) >= Array.IndexOf(preferences[u], people[u])) continue;
                    firstPersonUnhappy = true;
                    break;
                }
                if (firstPersonUnhappy) res++;
                var secondPersonUnhappy = false;
                for (int j = 0; j < preferences[people[i]].Length; j++)
                {
                    var u = preferences[people[i]][j];
                    if (u == i) break;
                    if (Array.IndexOf(preferences[u], people[i]) >= Array.IndexOf(preferences[u], people[u])) continue;
                    secondPersonUnhappy = true;
                    break;
                }
                if (secondPersonUnhappy) res++;
            }
            return res / 2;
        }
    }
}
