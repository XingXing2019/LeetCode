//创建li和hi指针分别指向数组头和尾。
//在li小于hi的条件下遍历，创建mid指向li和hi的中点。如果mid指向的数字大于其下一个数字，则使hi移动到mid。否则使li移动到mid的下一个位置。最后返回li即可。
using System;

namespace PeakIndexInAMountainArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 1, 0 };
            Console.WriteLine(PeakIndexInMountainArray(A));
        }
        static int PeakIndexInMountainArray(int[] A)
        {
            int li = 0;
            int hi = A.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (A[mid] > A[mid + 1])
                    hi = mid;
                else if (A[mid] < A[mid + 1])
                    li = mid + 1;
            }
            return li;
        }
    }
}
