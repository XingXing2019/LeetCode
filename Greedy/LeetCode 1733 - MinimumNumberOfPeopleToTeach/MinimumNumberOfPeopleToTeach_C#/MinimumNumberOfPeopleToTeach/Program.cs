using System;
using System.Collections.Generic;

namespace MinimumNumberOfPeopleToTeach
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            int[][] languages = new int[][]
            {
                new int[] {1},
                new int[] {2},
                new int[] {1, 2},
            };
            int[][] friendships = new int[][]
            {
                new int[] {1, 2},
                new int[] {1, 3},
                new int[] {2, 3},
            };
            Console.WriteLine(MinimumTeachings(n, languages, friendships));
        }
        static int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            var matrix = new bool[languages.Length][];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = new bool[n];
            for (int i = 0; i < languages.Length; i++)
            {
                for (int j = 0; j < languages[i].Length; j++)
                    matrix[i][languages[i][j] - 1] = true;
            }
            var friends = new List<int[]>();
            foreach (var friendship in friendships)
            {
                var knowSameLanguage = false;
                for (int i = 0; i < n; i++)
                {
                    if (!matrix[friendship[0] - 1][i] || !matrix[friendship[1] - 1][i]) continue;
                    knowSameLanguage = true;
                    break;
                }
                if(!knowSameLanguage) friends.Add(friendship);
            }
            var res = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                var set = new HashSet<int>();
                foreach (var friend in friends)
                {
                    if (!matrix[friend[0] - 1][i]) set.Add(friend[0]);
                    if (!matrix[friend[1] - 1][i]) set.Add(friend[1]);
                }
                res = Math.Min(res, set.Count);
            }
            return res;
        }
    }
}
