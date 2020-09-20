using System;

namespace SumOfAllOddLengthSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 11, 12 };
            Console.WriteLine(SumOddLengthSubarrays(arr));
        }
        static int SumOddLengthSubarrays(int[] arr)
        {
            var prefix = new int[arr.Length + 1];
            prefix[1] = arr[0];
            for (int i = 2; i < prefix.Length; i++)
                prefix[i] = prefix[i - 1] + arr[i - 1];
            int sum = 0;
            for (int i = 0; i < prefix.Length; i++)
            {
                for (int j = 1; i - j >= 0; j+=2)
                {
                    sum += prefix[i] - prefix[i - j];
                }
            }
            return sum;
        }
    }
}
