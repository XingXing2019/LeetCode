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
            if (arr[0] > k) return k;
            k -= arr[0] - 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] != 1)
                {
                    if (k - (arr[i] - arr[i - 1] - 1) <= 0)
                        return arr[i - 1] + k;
                    k -= arr[i] - arr[i - 1] - 1;
                }
            }
            return arr[^1] + k;
        }
    }
}
