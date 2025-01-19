var heightMap = new int[][]
{
    new[] { 12, 13, 1 },
    new[] { 13, 4, 13 },
    new[] { 13, 8, 10 },
    new[] { 12, 13, 12 },
};
Console.WriteLine(TrapRainWater(heightMap));

int TrapRainWater(int[][] heightMap)
{
    int m = heightMap.Length, n = heightMap[0].Length, res = 0, curHeight = -1;
    var visited = new bool[m][];
    var queue = new PriorityQueue<int[], int>();
    for (int x = 0; x < m; x++)
    {
        visited[x] = new bool[n];
        for (int y = 0; y < n; y++)
        {
            if (x != 0 && x != m - 1 && y != 0 && y != n - 1) continue;
            queue.Enqueue(new[] { x, y, heightMap[x][y] }, heightMap[x][y]);
            visited[x][y] = true;
        }
    }
    int[] dir = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], height = cur[2];
        curHeight = Math.Max(curHeight, height);
        res += curHeight - heightMap[x][y];
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= m || newY < 0 || newY >= n || visited[newX][newY])
                continue;
            visited[newX][newY] = true;
            queue.Enqueue(new[] { newX, newY, heightMap[newX][newY] }, heightMap[newX][newY]);
        }
    }
    return res;
}