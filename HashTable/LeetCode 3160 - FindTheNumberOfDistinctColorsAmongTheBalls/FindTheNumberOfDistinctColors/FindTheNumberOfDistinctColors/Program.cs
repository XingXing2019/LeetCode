var limit = 4;
int[][] queries = new[]
{
    new[] { 1, 4 },
    new[] { 2, 5 },
    new[] { 1, 3 },
    new[] { 3, 4 },
};
Console.WriteLine(QueryResults(limit, queries));

int[] QueryResults(int limit, int[][] queries)
{
    var res = new int[queries.Length];
    var balls = new Dictionary<int, int>();
    var colors = new Dictionary<int, int>();
    for (var i = 0; i < queries.Length; i++)
    {
        int x = queries[i][0], y = queries[i][1];
        if (balls.ContainsKey(x))
        {
            colors[balls[x]]--;
            if (colors[balls[x]] == 0)
                colors.Remove(balls[x]);
        }
        if (!colors.ContainsKey(y))
            colors[y] = 0;
        colors[y]++;
        balls[x] = y;
        res[i] = colors.Count;
    }
    return res;
}