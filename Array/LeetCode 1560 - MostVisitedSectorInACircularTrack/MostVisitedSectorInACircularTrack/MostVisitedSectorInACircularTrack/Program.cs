using System;
using System.Collections.Generic;
using System.Linq;

namespace MostVisitedSectorInACircularTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] rounds = {1, 3, 1, 2};
            Console.WriteLine(MostVisited(n, rounds));
        }
        static IList<int> MostVisited(int n, int[] rounds)
        {
            var visits = new int[n + 1];
            visits[rounds[0]]++;
            for (int i = 1; i < rounds.Length; i++)
            {
                int start = rounds[i - 1] + 1;
                int end = rounds[i] < rounds[i - 1] ? rounds[i] + n : rounds[i];
                for (int j = start; j <= end; j++)
                {
                    int index = j < visits.Length ? j : j - n;
                    visits[index]++;
                }
            }
            var max = visits.Max();
            var res = new List<int>();
            for (int i = 0; i < visits.Length; i++)
            {
                if(visits[i] == max)
                    res.Add(i);
            }
            return res;
        }
    }
}
