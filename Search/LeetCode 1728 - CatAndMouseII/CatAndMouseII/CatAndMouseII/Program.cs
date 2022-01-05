using System;

namespace CatAndMouseII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] grid = { "C#F", "###", "M.#" };
            int catJump = 3, mouseJump = 6;
            Console.WriteLine(CanMouseWin(grid, catJump, mouseJump));
        }

        public static bool CanMouseWin(string[] grid, int catJump, int mouseJump)
        {
            int mouseX = 0, mouseY = 0;
            int catX = 0, catY = 0;
            var dp = new int[70][][];
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (grid[x][y] == 'M')
                    {
                        mouseX = x;
                        mouseY = y;
                    }
                    else if (grid[x][y] == 'C')
                    {
                        catX = x;
                        catY = y;
                    }
                }
            }
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid.Length + grid[0].Length * 10][];
                for (int j = 0; j < dp[i].Length; j++)
                    dp[i][j] = new int[grid.Length + grid[0].Length * 10];
            }
            return DFS(grid, dp, 0, mouseX + mouseY * 10, mouseJump, catX + catY * 10, catJump) == 1;
        }

        public static int DFS(string[] grid, int[][][] dp, int turn, int mouse, int mouseJump, int cat, int catJump)
        {
            int mouseX = mouse % 10, mouseY = mouse / 10 % 10;
            int catX = cat % 10, catY = cat / 10 % 10;
            if (grid[mouseX][mouseY] == 'F') return 1;
            if (turn >= 70 || grid[catX][catY] == 'F' || cat == mouse) return 2;
            if (dp[turn][mouse][cat] != 0) return dp[turn][mouse][cat];
            int[] dir = { 1, 0, -1, 0, 1 };
            if (turn % 2 == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j <= mouseJump; j++)
                    {
                        int newX = mouseX + j * dir[i], newY = mouseY + j * dir[i + 1];
                        if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == '#')
                            break;
                        var next = DFS(grid, dp, turn + 1, newX + 10 * newY, mouseJump, cat, catJump);
                        if (next == 1)
                            return dp[turn][mouse][cat] = 1;
                    }
                }
                dp[turn][mouse][cat] = 2;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j <= catJump; j++)
                    {
                        int newX = catX + j * dir[i], newY = catY + j * dir[i + 1];
                        if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == '#')
                            break;
                        var next = DFS(grid, dp, turn + 1, mouse, mouseJump, newX + 10 * newY, catJump);
                        if (next == 2)
                            return dp[turn][mouse][cat] = 2;
                    }
                }
                dp[turn][mouse][cat] = 1;
            }
            return dp[turn][mouse][cat];
        }
    }
}
