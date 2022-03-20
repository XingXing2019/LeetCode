using System;
using System.Linq;

namespace CountCollisionsOnARoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountCollisions(string directions)
        {
            var block = false;
            var collisions = new bool[directions.Length];
            var res = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == 'R' || directions[i] == 'S')
                    block = true;
                else
                    collisions[i] = block;
            }
            block = false;
            for (int i = directions.Length - 1; i >= 0; i--)
            {
                if (directions[i] == 'L' || directions[i] == 'S')
                    block = true;
                else
                    collisions[i] = block;
            }
            return collisions.Count(x => x);
        }
    }
}
