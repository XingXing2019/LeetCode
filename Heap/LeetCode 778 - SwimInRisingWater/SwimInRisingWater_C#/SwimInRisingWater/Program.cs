int[][] grid =
{
    new[] { 3, 2 },
    new[] { 0, 1 },
};

Console.WriteLine(SwimInWater(grid));

int SwimInWater(int[][] grid)
{
    var heap = new PriorityQueue<int[], int>();
    var visited = new bool[grid.Length][];
    for (int i = 0; i < visited.Length; i++)
        visited[i] = new bool[grid[0].Length];
    heap.Enqueue(new[] { 0, 0, grid[0][0] }, grid[0][0]);
    visited[0][0] = true;
    int[] dir = { 1, 0, -1, 0, 1 };
    while (heap.Count != 0)
    {
        var cur = heap.Dequeue();
        if (cur[0] == grid.Length - 1 && cur[1] == grid[0].Length - 1)
            return cur[2];
        for (int i = 0; i < 4; i++)
        {
            int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid.Length || visited[newX][newY])
                continue;
            visited[newX][newY] = true;
            var t = cur[2] > grid[newX][newY] ? cur[2] : grid[newX][newY];
            heap.Enqueue(new []{newX, newY, t }, t);
        }
    }
    return -1;
}