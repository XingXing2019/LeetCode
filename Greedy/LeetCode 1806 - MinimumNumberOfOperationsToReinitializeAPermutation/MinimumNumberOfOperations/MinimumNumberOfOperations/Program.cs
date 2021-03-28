using System;

namespace MinimumNumberOfOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            Console.WriteLine(ReinitializePermutation(n));
        }
        public static int ReinitializePermutation(int n)
        {
            var perm = new int[n];
            for (int i = 0; i < n; i++)
                perm[i] = i;
            var match = false;
            int res = 0;
            while (!match)
            {
                int[] arr = new int[n];
                var temp = true;
                for (int i = 0; i < n; i++)
                {
                    arr[i] = i % 2 == 0 ? perm[i / 2] : perm[n / 2 + (i - 1) / 2];
                    temp = temp && arr[i] == i;
                }
                match = temp;
                perm = arr;
                res++;
            }
            return res;
        }
    }
}
