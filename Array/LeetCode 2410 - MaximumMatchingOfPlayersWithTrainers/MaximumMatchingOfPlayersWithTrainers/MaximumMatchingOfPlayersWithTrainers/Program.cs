using System;

namespace MaximumMatchingOfPlayersWithTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MatchPlayersAndTrainers(int[] players, int[] trainers)
        {
            Array.Sort(players);
            Array.Sort(trainers);
            int p1 = 0, p2 = 0, res = 0;
            while (p1 < players.Length && p2 < trainers.Length)
            {
                if (players[p1] <= trainers[p2])
                {
                    res++;
                    p1++;
                }
                p2++;
            }
            return res;
        }
    }
}
