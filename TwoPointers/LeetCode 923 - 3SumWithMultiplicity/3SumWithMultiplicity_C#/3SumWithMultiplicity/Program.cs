using System;
using System.Linq;
using System.Security.Cryptography;

namespace _3SumWithMultiplicity
{
    class Program
    {
        static void Main(string[] args)
        {
            //           0  1  2  3  4  5  6  7  8  9
            int[] arr = {1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
            int target = 8;
            Console.WriteLine(ThreeSumMulti(arr, target));
        }
        static int ThreeSumMulti(int[] arr, int target)
        {
            Array.Sort(arr);
            int mod = 1_000_000_000 + 7;
            long res = 0;
            var dict = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            for (int i = 0; i < arr.Length; i++)
            {
                int li = i + 1, hi = arr.Length - 1;
                while (li < hi)
                {
                    if (arr[li] + arr[hi] < target - arr[i])
                        li++;
                    else if (arr[li] + arr[hi] > target - arr[i])
                        hi--;
                    else
                    {
                        int count = 0, num = arr[li];
                        if (arr[hi] == num)
                        {
                            res += (hi - li + 1) * (hi - li) / 2;
                            break;
                        }
                        while (li < hi && arr[li] == num)
                        {
                            li++;
                            count++;
                        }
                        res += count * dict[arr[hi]];
                    }
                }
            }
            return (int) (res % mod);
        }
    }
}
