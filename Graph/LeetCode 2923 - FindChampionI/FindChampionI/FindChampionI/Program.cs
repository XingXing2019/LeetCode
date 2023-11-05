int FindChampion(int[][] grid)
{
    var n = grid.Length;
    var inDegree = new int[n];
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 0) continue;
            inDegree[i]++;
            if (inDegree[i] == n - 1)
                return i;
        }
    }
    return -1;
}