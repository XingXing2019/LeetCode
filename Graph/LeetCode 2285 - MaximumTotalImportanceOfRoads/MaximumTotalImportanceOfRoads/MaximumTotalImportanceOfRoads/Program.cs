using System;

namespace MaximumTotalImportanceOfRoads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MaximumImportance(int n, int[][] roads)
        {
            var degree = new int[n];
            foreach (var road in roads)
            {
                degree[road[0]]++;
                degree[road[1]]++;
            }
            Array.Sort(degree, (a, b) => b - a);
            long res = 0;
            for (int i = 0; i < degree.Length; i++)
            {
                res += (long) n * degree[i];
                n--;
            }
            return res;
        }
    }
}
