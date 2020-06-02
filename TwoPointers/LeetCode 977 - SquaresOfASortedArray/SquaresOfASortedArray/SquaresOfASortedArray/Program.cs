//创建res数组接收结果，长度和A一样。创建li和hi指针，分别指向A的第一个和最后一个元素。
//逆序遍历res，如果li指向数字的平方大于hi指向数字的平方，则将res[i]设为li指向数字的平方，并让li向右移动一位。
//否则将res[i]设为hi指向数字的平方，并让hi向左移动一位。
using System;

namespace SquaresOfASortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] SortedSquares(int[] A)
        {
            int[] res = new int[A.Length];
            int li = 0;
            int hi = A.Length - 1;
            for (int i = res.Length - 1; i >= 0; i--)
            {
                if (A[li] * A[li] > A[hi] * A[hi])
                    res[i] = A[li] * A[li++];
                else
                    res[i] = A[hi] * A[hi--];
            }
            return res;
        }
    }
}
