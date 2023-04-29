using System;
using System.Collections.Generic;

namespace FindThePrefixCommonArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            var freq = new Dictionary<int, int>();
            var res = new int[A.Length];
            for (int i = 0; i < res.Length; i++)
            {
                if (!freq.ContainsKey(A[i]))
                    freq[A[i]] = 0;
                freq[A[i]]++;
                if (!freq.ContainsKey(B[i]))
                    freq[B[i]] = 0;
                freq[B[i]]++;
            }
            for (int i = 0; i < res.Length; i++)
            {
                freq[A[i]]--;
                if (freq[A[i]] == 0)
                    freq.Remove(A[i]);
                freq[B[i]]--;
                if (freq[B[i]] == 0)
                    freq.Remove(B[i]);
                res[i] = res.Length - freq.Count;
            }
            return res;
        }
    }
}
