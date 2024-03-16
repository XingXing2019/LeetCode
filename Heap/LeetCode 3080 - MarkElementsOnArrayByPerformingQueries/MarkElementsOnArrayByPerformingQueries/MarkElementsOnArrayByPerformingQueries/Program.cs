int[] nums = { 1, 2, 2, 1, 2, 3, 1 };
int[][] queries = new int[][]
{
    new[] { 1, 2 },
    new[] { 3, 3 },
    new[] { 2, 2 },
};
Console.WriteLine(UnmarkedSumArray(nums, queries));

long[] UnmarkedSumArray(int[] nums, int[][] queries)
{
    var heap = new PriorityQueue<int[], long>();
    long sum = 0, power = 100000;
    var res = new long[queries.Length]; 
    var marked = new HashSet<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        heap.Enqueue(new[] { nums[i], i }, nums[i] * power + i);
    }
    for (int i = 0; i < queries.Length; i++)
    {
        int index = queries[i][0], k = queries[i][1];
        if (marked.Add(index))
            sum -= nums[index];
        while (k != 0 && heap.Count != 0)
        {
            var min = heap.Dequeue();
            if (!marked.Add(min[1])) continue;
            sum -= min[0];
            k--;
        }
        res[i] = sum;
    }
    return res;
}