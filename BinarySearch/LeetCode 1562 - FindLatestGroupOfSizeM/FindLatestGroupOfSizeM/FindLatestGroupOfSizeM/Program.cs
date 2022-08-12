using System;
using System.Collections.Generic;

namespace FindLatestGroupOfSizeM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindLatestStep(int[] arr, int m)
        {
            if (arr.Length == m) return arr.Length;
            var edges = new List<int>{0, arr.Length + 1};
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var edge = arr[i];
                var index = edges.BinarySearch(edge);
                index = ~index;
                if (edge - edges[index - 1] - 1 == m || edges[index] - edge - 1 == m)
                    return i;
                edges.Insert(index, edge);
            }
            return -1;
        }
    }
}
