long MaxSum(int[][] grid, int[] limits, int k)
{
    var heap = new PriorityQueue<int, int>();
    for (var i = 0; i < grid.Length; i++)
    {
        Array.Sort(grid[i], (a, b) => b - a);
        for (int j = 0; j < limits[i]; j++)
        {
            heap.Enqueue(grid[i][j], grid[i][j]);
            if (heap.Count > k)
                heap.Dequeue();
        }
    }
    var res = 0L;
    while (heap.Count != 0)
        res += heap.Dequeue();
    return res;
}