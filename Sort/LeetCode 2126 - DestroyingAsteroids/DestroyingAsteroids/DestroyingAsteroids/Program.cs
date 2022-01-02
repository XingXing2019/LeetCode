
using System;

namespace DestroyingAsteroids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool AsteroidsDestroyed(int mass, int[] asteroids)
        {
            long sum = mass;
            Array.Sort(asteroids);
            foreach (var asteroid in asteroids)
            {
                if (sum < asteroid)
                    return false;
                sum += asteroid;
            }
            return true;
        }
    }
}
