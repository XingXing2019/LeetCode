using System;
using System.Runtime.InteropServices;

namespace XORQueriesOfASubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 3, c = 4, d = 8;
            Console.WriteLine(a ^ b ^ c ^ d);
        }
        static int[] XorQueries(int[] arr, int[][] queries)
        {
            var res = new int[queries.Length];
            var preXor = new int[arr.Length];
            preXor[0] = arr[0];
            for (int i = 1; i < preXor.Length; i++)
                preXor[i] = preXor[i - 1] ^ arr[i];
            for (int i = 0; i < queries.Length; i++)
            {
                if (queries[i][0] == 0)
                    res[i] = preXor[queries[i][1]];
                else
                    res[i] = preXor[queries[i][1]] ^ preXor[queries[i][0] - 1];
            }
            return res;
        }
    }
}
