using System;
using System.Collections.Generic;

namespace FindAnagramMappings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] AnagramMappings(int[] A, int[] B)
        {
            var index = new Dictionary<int, List<int>>();
            for (int i = 0; i < B.Length; i++)
            {
                if (!index.ContainsKey(B[i]))
                    index[B[i]] = new List<int> {i};
                else
                    index[B[i]].Add(i);
            }
            for (int i = 0; i < A.Length; i++)
            {
                var temp = A[i];
                A[i] = index[temp][^1];
                index[temp].RemoveAt(index[temp].Count - 1);
            }
            return A;
        }
    }
}
