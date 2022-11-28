using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPlayersWithZeroOrOneLosses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var teams = new HashSet<int>();
            var loss = new Dictionary<int, int>();
            foreach (var match in matches)
            {
                teams.Add(match[0]);
                teams.Add(match[1]);
                if (!loss.ContainsKey(match[1]))
                    loss[match[1]] = 0;
                loss[match[1]]++;
            }
            return new List<IList<int>>
            {
                teams.Where(x => !loss.ContainsKey(x)).OrderBy(x => x).ToList(),
                teams.Where(x => loss.ContainsKey(x) && loss[x] == 1).OrderBy(x => x).ToList()
            };
        }
    }
}
