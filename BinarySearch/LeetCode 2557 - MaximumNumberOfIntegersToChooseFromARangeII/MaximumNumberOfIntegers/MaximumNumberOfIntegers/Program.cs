using System;

namespace MaximumNumberOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] banned = { 271404187 };
            int n = 506731976;
            long maxSum = 396871319768398;
            Console.WriteLine(MaxCount(banned, n, maxSum));
        }

        public static int MaxCount(int[] banned, int n, long maxSum)
        {
            Array.Sort(banned);
            long existingSum = 0;
            var res = 0;
            for (int i = 0; i < banned.Length; i++)
            {
                long start = i == 0 ? 1 : banned[i - 1] + 1;
                long end = banned[i] - 1;
                if (start > end) continue;
                var count = BinarySearch(start, end, existingSum, maxSum);
                res += count;
                existingSum += (start + start + count - 1) * count / 2;
            }
            if (n - banned[^1] > 0)
                res += BinarySearch(banned[^1] + 1, n, existingSum, maxSum);
            return res;
        }

        private static int BinarySearch(long start, long end, long existingSum, long maxSum)
        {
            long li = 1, hi = end - start + 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var sum = (start + start + mid - 1) * mid / 2;
                if (existingSum + sum > maxSum)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return (int) hi;
        }
    }
}
