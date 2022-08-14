using System;

namespace NodeWithHighestEdgeScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int EdgeScore(int[] edges)
        {
            var score = new long[edges.Length];
            long max = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                score[edges[i]] += i;
                max = Math.Max(max, score[edges[i]]);
            }
            return Array.IndexOf(score, max);
        }
    }
}
