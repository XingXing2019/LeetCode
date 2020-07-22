using System;

namespace FixedPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {0, 1, 3, 7, 8, 9};
            Console.WriteLine(FixedPoint(A));
        }
        static int FixedPoint(int[] A)
        {
            int li = 0, hi = A.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (A[mid] < mid)
                    li = mid + 1;
                else
                    hi = mid;
            }
            return A[li] == li ? li : -1;
        }
    }
}
