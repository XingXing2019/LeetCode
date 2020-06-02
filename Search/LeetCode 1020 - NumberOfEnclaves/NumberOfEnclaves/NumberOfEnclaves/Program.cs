//深搜地图，利用area记录面积，isOnBoundary记录是否临近边界。注意两个值都要传引用。
//如果不离近边界，则返回area，否则返回0. 
using System;

namespace NumberOfEnclaves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[10][];
            A[0] = new int[] { 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 };
            A[1] = new int[] { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0 };
            A[2] = new int[] { 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0 };
            A[3] = new int[] { 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1 };
            A[4] = new int[] { 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0 };
            A[5] = new int[] { 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 };
            A[6] = new int[] { 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0 };
            A[7] = new int[] { 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0 };
            A[8] = new int[] { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0 };
            A[9] = new int[] { 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1 };
            Console.WriteLine(NumEnclaves(A));
        }
        static int NumEnclaves(int[][] A)
        {
            int res = 0;
            int[][] mark = new int[A.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[A[0].Length];
            for (int x = 0; x < A.Length; x++)
            {
                for (int y = 0; y < A[0].Length; y++)
                {
                    if (mark[x][y] == 0 && A[x][y] == 1)
                    {
                        int area = 0;
                        bool isOnBoundary = false;
                        res += DFS(A, mark, x, y, ref area, ref isOnBoundary);
                    }                    
                }
            }
            return res;
        }
        static int DFS(int[][] A, int[][] mark, int x, int y, ref int area, ref bool isOnBoundary)
        {
            area++;
            mark[x][y] = 1;
            if (x == 0 || x == A.Length - 1 || y == 0 || y == A[0].Length - 1)
                isOnBoundary = true;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if (newX < 0 || newX >= A.Length || newY < 0 || newY >= A[0].Length)
                    continue;
                if(mark[newX][newY] == 0 && A[newX][newY] == 1)
                   area = DFS(A, mark, newX, newY, ref area, ref isOnBoundary);
            }
            if (isOnBoundary)
                return 0;
            else
                return area;
        }
    }
}
