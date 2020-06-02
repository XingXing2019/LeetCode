using System;

namespace KthSmallestElementInASortedMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] {1, 5, 9};
            matrix[1] = new int[] {10, 11, 13};
            matrix[2] = new int[] {12, 13, 15};
            int k = 9;
            Console.WriteLine(KthSmallest(matrix, k));
        }
        static int KthSmallest(int[][] matrix, int k)
        {
            int li = matrix[0][0], hi = matrix[^1][^1] + 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int position = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    int temp = Array.BinarySearch(matrix[i], mid);
                    position += temp < 0 ? -(temp + 1) : temp;
                }
                if (position + 1 <= k)
                    li = mid + 1;
                else
                    hi = mid;
            }
            return li - 1;
        }

      
    }
}
