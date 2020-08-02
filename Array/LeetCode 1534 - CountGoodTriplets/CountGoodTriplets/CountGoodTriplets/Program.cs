using System;

namespace CountGoodTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b &&
                            Math.Abs(arr[i] - arr[k]) <= c)
                            res++;
                    }
                }
            }
            return res;
        }
    }
}
