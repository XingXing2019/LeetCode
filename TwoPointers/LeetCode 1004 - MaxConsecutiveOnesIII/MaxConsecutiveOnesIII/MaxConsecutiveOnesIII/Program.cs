//创建li和hi指针维护一个滑动窗口，初始值指向数组第一个元素。创建max记录最长的连续1。
//在hi指针不越界的条件下遍历数组。如果hi指针指向的元素为1，则令hi向右移动一位。
//否则当K不为0时令hi向右移动一位，同时K减一。当K等于0时，证明此时的窗口为当前状态下能达到的最大窗口，则令max等于max与此时窗口宽度中较大的一个。
//并让li向右移动，并在其划过0时，使K加一以寻求下一次机会得到更大的窗口。逻辑为在K等于0的条件下循环，如果里指向的数字为0，则使K加一，并且li右移一位。
//遍历结束后还需要在令max等于其与最后一次窗口宽度中较大的值。
using System;

namespace MaxConsecutiveOnesIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            int K = 3;
            Console.WriteLine(LongestOnes(A, K));
        }
        static int LongestOnes(int[] A, int K)
        {
            int li = 0;
            int hi = 0;
            int max = 0;
            while(hi< A.Length)
            {
                if(A[hi] == 1)
                    hi++;
                else
                {
                    if(K != 0)
                    {
                        hi++;
                        K--;
                    }
                    else
                    {
                        max = Math.Max(max, hi - li);
                        while (K == 0)
                            if (A[li++] == 0)
                                K++;
                    }
                }
            }
            max = Math.Max(max, hi - li);
            return max;
        }
    }
}
