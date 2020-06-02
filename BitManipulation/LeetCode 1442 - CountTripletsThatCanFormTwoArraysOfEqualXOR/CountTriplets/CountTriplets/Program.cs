using System;

namespace CountTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 3, 1, 6, 7};
            Console.WriteLine(CountTriplets(arr));
        }

       static int CountTriplets(int[] arr)
        {
            int res = 0;
            var preXOR = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
                preXOR[i + 1] = arr[i] ^ preXOR[i];
            for (int k = 1; k < arr.Length; k++)
                for (int j = 1; j <= k; j++)
                    for (int i = 0; i < j; i++)
                        res += (preXOR[j] ^ preXOR[i]) == (preXOR[k + 1] ^ preXOR[j]) ? 1 : 0;
            return res;
        }
    }
}
