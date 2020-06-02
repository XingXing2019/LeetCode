using System;

namespace KConcatenationMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, -1, 2, 3, -3 };
            int k = 1;
            Console.WriteLine(KConcatenationMaxSum1(arr, k));
        }

        static int KConcatenationMaxSum1(int[] arr, int k)
        {
            long presum = 0, maxpresum = 0;
            long endsum = 0, maxendsum = 0;
            long subsum = 0, maxsubsum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                presum += arr[i];
                maxpresum = Math.Max(presum, maxpresum);
                endsum += arr[arr.Length - 1 - i];
                maxendsum = Math.Max(endsum, maxendsum);
                if (subsum < 0)
                    subsum = arr[i];
                else
                    subsum += arr[i];
                maxsubsum = Math.Max(subsum, maxsubsum);
            }
            if (k == 1)
                return (int) (maxsubsum % 1000000007);
            else
            {
                int max1 = (int) (maxsubsum % 1000000007);
                int max2 = (int) ((maxpresum + maxendsum) % 1000000007);
                int max3 = (int) ((maxpresum + maxendsum + presum * (k - 2)) % 1000000007);
                return Math.Max(Math.Max(max1, max2), max3);
            }
        }

        static int KConcatenationMaxSum2(int[] arr, int k)
            {
                int len = arr.Length * k;
                int index = 0;
                int sumToBegin = 0;
                int minSum = 0;
                int res = arr[0];
                while (index < len)
                {
                    int tem = index % arr.Length;
                    sumToBegin += arr[tem] % 1000000007;
                    minSum = Math.Min(minSum, sumToBegin);
                    res = Math.Max(res, sumToBegin - minSum);
                    index++;
                }

                return res;
            }
        }
    
}
