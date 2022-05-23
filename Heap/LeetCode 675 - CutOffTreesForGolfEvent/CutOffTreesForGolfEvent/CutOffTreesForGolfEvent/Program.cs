var forest = new List<IList<int>>
{
    new List<int> { 1, 2, 3 },
    new List<int> { 0, 0, 0 },
    new List<int> { 7, 6, 5 },
};

Console.WriteLine(CutOffTree(forest));

int CutOffTree(IList<IList<int>> forest)
{
    var trees = new List<int[]>();
    for (int i = 0; i < forest.Count; i++)
    {
        for (int j = 0; j < forest[0].Count; j++)
        {
            if (forest[i][j] <= 1) continue;
            trees.Add(new []{i, j, forest[i][j]});
        }
    }
    var res = 0;
    int[] cur = { 0, 0 };
    trees = trees.OrderBy(x => x[2]).ToList();
    for (int i = 0; i < trees.Count; i++)
    {
        var target = new int[] { trees[i][0], trees[i][1] };
        var step = BFS(forest, cur, target);
        if (step == -1) return -1;
        res += step;
        cur = target;
    }
    return res;
}

int BFS(IList<IList<int>> forest, int[] start, int[] end)
{
    int m = forest.Count, n = forest[0].Count;
    var dp = new int[m][];
    for (int i = 0; i < m; i++)
    {
        dp[i] = new int[n];
        Array.Fill(dp[i], int.MaxValue);
    }
    var queue = new Queue<int[]>();
    queue.Enqueue(new[] { start[0], start[1], 0 });
    dp[start[0]][start[1]] = 0;
    int[] dirs = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        if (cur[0] == end[0] && cur[1] == end[1])
            return cur[2];
        for (int i = 0; i < 4; i++)
        {
            int newX = cur[0] + dirs[i], newY = cur[1] + dirs[i + 1];
            if (newX < 0 || newX >= m || newY < 0 || newY >= n || forest[newX][newY] == 0 || dp[newX][newY] <= cur[2] + 1) continue;
            dp[newX][newY] = cur[2] + 1;
            queue.Enqueue(new []{newX, newY, cur[2] + 1});
        }
    }
    return -1;
}