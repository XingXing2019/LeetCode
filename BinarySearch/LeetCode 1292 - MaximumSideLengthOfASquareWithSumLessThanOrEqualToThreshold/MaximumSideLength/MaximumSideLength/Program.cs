using System;

namespace MaximumSideLength
{
    class Program
    {
        static void Main(string[] args)
        {
            var mat = new int[][]
            {
                new[] {18, 70},
                new[] {61, 1},
                new[] {25, 85},
                new[] {14, 40},
                new[] {11, 96},
                new[] {97, 96},
                new[] {63, 45},
            };
            int threshold = 1;
            Console.WriteLine(MaxSideLength(mat, threshold));
        }
        static int MaxSideLength(int[][] mat, int threshold)
        {
            var prefix = new int[mat.Length][];
            for (int r = 0; r < prefix.Length; r++)
            {
                if(prefix[r] == null) prefix[r] = new int[mat[0].Length];
                for (int c = 0; c < prefix[r].Length; c++)
                {
                    if (c == 0) prefix[r][c] = mat[r][c];
                    else prefix[r][c] = prefix[r][c - 1] + mat[r][c];
                }
            }
            int li = 0, hi = Math.Min(mat.Length, mat[0].Length);
            var found = false;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                found = false;
                for (int r = mid - 1; r < prefix.Length; r++)
                {
                    for (int c = mid - 1; c < prefix[0].Length; c++)
                    {
                        var temp = 0;
                        for (int i = 0; i < mid; i++)
                            temp += c == mid - 1 ? prefix[r - i][c] - 0 : prefix[r - i][c] - prefix[r - i][c - mid];
                        if (temp <= threshold)
                        {
                            found = true;
                            break;
                        }
                    }
                    if(found) break;
                }
                if (found && li < hi) li = mid + 1;
                else hi = mid - 1;
            }
            return found ? li : li - 1;
        }
    }
}
