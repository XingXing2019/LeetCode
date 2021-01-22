//先将每行翻转，再将每个数字变换。
using System;

namespace FlippingAnImage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[][] FlipAndInvertImage(int[][] A)
        {
            int row = A.Length, col = A[0].Length;
            for (int r = 0; r < row; r++)
                Array.Reverse(A[r]);
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    A[r][c] = A[r][c] == 0 ? 1 : 0;
            return A;
        }
    }
}
