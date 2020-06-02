using System;

namespace ImageSmoother
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] M = new int[3][];
            M[0] = new int[] {1, 1, 1};
            M[1] = new int[] {1, 0, 1};
            M[2] = new int[] {1, 1, 1};
            Console.WriteLine(ImageSmoother(M));
        }
        static int[][] ImageSmoother(int[][] M)
        {
            int[][] res = new int[M.Length][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[M[0].Length];
            int[] dx = {-1, -1, -1, 0, 0, 1, 1, 1};
            int[] dy = {-1, 0, 1, -1, 1, -1, 0, 1};
            for (int x = 0; x < M.Length; x++)
            {
                for (int y = 0; y < M[0].Length; y++)
                {
                    int tem = M[x][y];
                    int count = 1;
                    for (int i = 0; i < 8; i++)
                    {
                        int newX = x + dx[i];
                        int newY = y + dy[i];
                        if(newX < 0 || newX >= M.Length || newY < 0 || newY >= M[0].Length)
                            continue;
                        tem += M[newX][newY];
                        count++;
                    }
                    res[x][y] = tem / count;
                }
            }
            return res;
        }
    }
}
