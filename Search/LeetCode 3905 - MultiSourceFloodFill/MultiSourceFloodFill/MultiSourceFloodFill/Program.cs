int n = 3, m = 3;
int[][] sources = new[]
{
    new[] { 0, 0, 1 },
    new[] { 2, 2, 2 },
};
Console.WriteLine(ColorGrid(n, m, sources));

int[][] ColorGrid(int n, int m, int[][] sources)
{
    sources = sources.OrderByDescending(x => x[2]).ToArray();
    var res = new int[n][];
    for (int i = 0; i < n; i++)
        res[i] = new int[m];
    var queue = new Queue<int[]>();
    foreach (var source in sources)
    {
        queue.Enqueue(source);
        res[source[0]][source[1]] = source[2];
    }
    int[] dir = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            int x = cur[0], y = cur[1], c = cur[2];
            for (int j = 0; j < 4; j++)
            {
                int newX = x + dir[j], newY = y + dir[j + 1];
                if (newX < 0 || newX >= n || newY < 0 || newY >= m || res[newX][newY] != 0) continue;
                queue.Enqueue(new[] { newX, newY, c });
                res[newX][newY] = c;
            }
        }
    }
    return res;
}