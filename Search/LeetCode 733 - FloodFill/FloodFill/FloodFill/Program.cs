//与LeetCode 200思路类似，使用深搜查找符合条件的单元格，并将其修改。
//深搜上下左右四个格子的时候可以使用两个方向数组简化代码。
using System;

namespace FloodFill
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] image = new int[3][];
            image[0] = new int[] {1, 1, 1};
            image[1] = new int[] {1, 1, 0};
            image[2] = new int[] {1, 0, 1};
            int sr = 1, sc = 1, newColor = 2;
            Console.WriteLine(FloodFill(image, sr, sc, newColor));
        }
        static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int[][] mark = new int[image.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[image[0].Length];
            int oldColor = image[sr][sc];
            Generate(image, sr, sc, newColor, mark, oldColor);
            return image;
        }

        static void Generate(int[][] image, int sr, int sc, int newColor, int[][] mark, int oldColor)
        {
            mark[sr][sc] = 1;
            image[sr][sc] = newColor;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newSr = sr + dx[i];
                int newSc = sc + dy[i];
                if(newSr < 0 || newSr >= image.Length || newSc < 0 || newSc >= image[0].Length)
                    continue;
                if(mark[newSr][newSc] == 0 && image[newSr][newSc] == oldColor)
                    Generate(image, newSr, newSc, newColor, mark, oldColor);
            }
        }
    }
}
