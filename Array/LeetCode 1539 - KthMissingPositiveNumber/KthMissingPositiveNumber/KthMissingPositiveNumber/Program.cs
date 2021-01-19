using System;

namespace KthMissingPositiveNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 3, 4, 7, 11};
            int k = 2;
            Console.WriteLine(FindKthPositive(arr, k));
        }
        static int FindKthPositive(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                k -= i == 0 ? arr[i] - 1 : arr[i] - arr[i - 1] - 1;
                if (k <= 0) return arr[i] + k - 1;
            }
            return arr[^1] + k;
        }
    }
}
