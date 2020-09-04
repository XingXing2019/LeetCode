using System;
using System.Collections.Generic;

namespace CinemaSeatAllocation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[][] reservedSeats = new[]
            {
                new[] {2,2},
                new[] {5,4},
                new[] {3,5},
                new[] {5,10},
                new[] {5,7},
                new[] {4,5},
            };
            Console.WriteLine(MaxNumberOfFamilies(n, reservedSeats));
        }
        static int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            var rows = new Dictionary<int, HashSet<int>>();
            foreach (var reservedSeat in reservedSeats)
            {
                if(!rows.ContainsKey(reservedSeat[0]))
                    rows[reservedSeat[0]] = new HashSet<int>();
                rows[reservedSeat[0]].Add(reservedSeat[1]);
            }
            var res = (n - rows.Count) * 2;
            foreach (var row in rows)
            {
                int count = 0;
                for (int i = 2; i < 10; i++)
                {
                    if(count == 0 && (i != 2 && i != 4 && i != 6)) continue;
                    if (!row.Value.Contains(i))
                        count++;
                    else
                        count = 0;
                    if(count == 4 && (i == 5 || i == 7 || i == 9))
                    {
                        res++;
                        count = 0;
                    }
                }
            }
            return res;
        }
    }
}
