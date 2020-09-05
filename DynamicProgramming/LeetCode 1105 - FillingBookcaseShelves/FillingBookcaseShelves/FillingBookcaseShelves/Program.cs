using System;

namespace FillingBookcaseShelves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] books = new[]
            {
                new[] {11, 83},
                new[] {73, 33},
                new[] {33, 138},
                new[] {95, 89},
            };
            int shelf_width = 200;
            Console.WriteLine(MinHeightShelves(books, shelf_width));
        }
        static int MinHeightShelves(int[][] books, int shelf_width)
        {
            var dp = new int[books.Length];
            dp[0] = books[0][1];
            for (int i = 1; i < dp.Length; i++)
            {
                int putTogether = int.MaxValue;
                int putSeperate = books[i][1] + dp[i - 1];
                int width = books[i][0], height = books[i][1];
                int pointer = i - 1;
                while (pointer >= 0 && width + books[pointer][0] <= shelf_width)
                {
                    height = Math.Max(height, books[pointer][1]);
                    width += books[pointer--][0];
                    putTogether = Math.Min(putTogether, height + (pointer == -1 ? 0 : dp[pointer]));
                }
                dp[i] = Math.Min(putTogether, putSeperate);
            }
            return dp[^1];
        }
    }
}
