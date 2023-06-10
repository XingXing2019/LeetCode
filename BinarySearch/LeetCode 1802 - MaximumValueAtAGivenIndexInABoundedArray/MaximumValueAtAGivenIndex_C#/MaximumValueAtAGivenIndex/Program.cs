using System;

namespace MaximumValueAtAGivenIndex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 6, index = 1, maxSum = 10;
            Console.WriteLine(MaxValue(n, index, maxSum));
        }

        public static int MaxValue(int n, int index, int maxSum)
        {
            long li = 1, hi = maxSum;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var frontCount = index + 1;
                var frontStart = mid;
                var front = frontStart >= frontCount
                    ? (frontStart + frontStart - frontCount + 1) * frontCount / 2
                    : (frontStart + 1) * frontStart / 2 + (frontCount - frontStart);
                var afterCount = n - index - 1;
                var afterStart = mid == 1 ? 1 : mid - 1;
                var after = afterStart >= afterCount
                    ? (afterStart + afterStart - afterCount + 1) * afterCount / 2
                    : (afterStart + 1) * afterStart / 2 + (afterCount - afterStart);
                if (front + after <= maxSum)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return (int) hi;
        }
    }
}
