using System;
using System.Linq;

namespace FurthestPointFromOrigin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        public int FurthestDistanceFromOrigin(string moves)
        {
            return Math.Max(GetDistance(moves.Replace('_', 'L')), GetDistance(moves.Replace('_', 'R')));
        }

        public int GetDistance(string moves)
        {
            return Math.Abs(moves.Count(x => x == 'L') - moves.Count(x => x == 'R'));
        }
    }
}
