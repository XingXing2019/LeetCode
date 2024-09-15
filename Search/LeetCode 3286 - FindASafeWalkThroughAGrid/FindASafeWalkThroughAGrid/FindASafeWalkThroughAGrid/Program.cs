using System.Collections;

var grid = new List<IList<int>>
{
    new List<int> { 1, 1, 1 },
    new List<int> { 1, 0, 1 },
    new List<int> { 1, 1, 1 },
};
var health = 5;
Console.WriteLine(FindSafeWalk(grid, health));

bool FindSafeWalk(IList<IList<int>> grid, int health)
{
    var dp = new int[grid.Count][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[grid[0].Count];
        Array.Fill(dp[i], int.MinValue);
    }
    dp[0][0] = health - grid[0][0];
    var queue = new Queue<int[]>();
    queue.Enqueue(new int[] { 0, 0, health - grid[0][0] });
    int[] dir = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], h = cur[2];
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= grid.Count || newY < 0 || newY >= grid[0].Count)
                continue;
            if (h - grid[newX][newY] > dp[newX][newY])
            {
                dp[newX][newY] = h - grid[newX][newY];
                queue.Enqueue(new[] { newX, newY, h - grid[newX][newY] });
            }
        }
    }
    return dp[^1][^1] > 0;
}