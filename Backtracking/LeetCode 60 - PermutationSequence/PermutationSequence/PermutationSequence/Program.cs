using System;
using System.Collections.Generic;

namespace PermutationSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4, k = 9;
            Console.WriteLine(GetPermutation(n, k));
        }
        static string GetPermutation(int n, int k)
        {
            var permutation = new int[10];
            permutation[0] = 1;
            for (int i = 1; i < permutation.Length; i++)
                permutation[i] = permutation[i - 1] * i;
            var res = "";
            var nums = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            while (n != 0)
            {
                var temp = (k - 1) / permutation[n - 1];
                res += nums[temp];
                nums.Remove(nums[temp]);
                k -= temp * permutation[n - 1];
                n--;
            }
            return res;
        }
    }
}
