using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeArrayStrictlyIncreasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 5, 3, 6, 7 };
            int[] arr2 = { 4, 3, 1 };
            Console.WriteLine(MakeArrayIncreasing(arr1, arr2));
        }

        public static int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            var max = 1_000_000_000;
            arr2 = new HashSet<int>(arr2).ToArray();
            Array.Sort(arr2);
            var keep = new int[arr1.Length];
            var swap = new int[arr1.Length][];
            for (int i = 0; i < arr1.Length; i++)
            {
                keep[i] = i == 0 ? 0 : max;
                swap[i] = new int[arr2.Length];
                Array.Fill(swap[i], i == 0 ? 1 : max);
            }
            for (int i = 1; i < arr1.Length; i++)
            {
                int minKeep = max, minSwap = max;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (j > 0) minSwap = Math.Min(minSwap, swap[i - 1][j - 1] + 1);
                    if (arr1[i] > arr2[j]) minKeep = Math.Min(minKeep, swap[i - 1][j]);
                    if (arr1[i] > arr1[i - 1]) keep[i] = keep[i - 1];
                    if (arr2[j] > arr1[i - 1]) swap[i][j] = keep[i - 1] + 1;
                    keep[i] = Math.Min(keep[i], minKeep);
                    swap[i][j] = Math.Min(swap[i][j], minSwap);
                }
            }
            var res = Math.Min(keep[^1], swap[^1].Min());
            return res >= max ? -1 : res;
        }
    }
}
