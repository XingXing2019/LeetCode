using System;
using System.Collections.Generic;

namespace FindTheLosersOfTheCircularGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] CircularGameLosers(int n, int k)
        {
            int person = 1, round = 1, index = 0;
            var visited = new HashSet<int>();
            while (visited.Add(person))
            {
                person = (person + k * round) % n;
                if (person == 0) person = n;
                round++;
            }
            var res = new int[n - visited.Count];
            for (int i = 1; i <= n; i++)
            {
                if (visited.Contains(i)) continue;
                res[index++] = i;
            }
            return res;
        }
    }
}
