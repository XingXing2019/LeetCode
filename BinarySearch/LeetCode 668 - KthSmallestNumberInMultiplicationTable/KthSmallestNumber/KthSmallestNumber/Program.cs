using System;

namespace KthSmallestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 3, n = 3, k = 2;
            Console.WriteLine(FindKthNumber(m, n, k));
        }
        public static int FindKthNumber(int m, int n, int k)
        {
            int li = 1, hi = m * n;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var smaller = 0;
                for (int i = 1; i <= m; i++)
                    smaller += FindSmaller(i, i * n, mid);
                if (smaller + 1 > k)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }

        public static int FindSmaller(int li, int hi, int target)
        {
            int first = li;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (mid < target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi / first;
        }
    }
}
