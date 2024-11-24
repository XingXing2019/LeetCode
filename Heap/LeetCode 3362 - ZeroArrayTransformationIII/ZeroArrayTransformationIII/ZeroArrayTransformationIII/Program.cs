int[] nums = { 2, 0, 2 };
int[][] queries = new[]
{
    new[] { 0, 2 },
    new[] { 0, 2 },
    new[] { 1, 1 },
};
Console.WriteLine(MaxRemoval(nums, queries));

int MaxRemoval(int[] nums, int[][] queries)
{
    var minHeap = new PriorityQueue<int, int>();
    var maxHeap = new PriorityQueue<int, int>();
    queries = queries.OrderBy(x => x[0]).ToArray();
    int index = 0, take = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        while (index < queries.Length && queries[index][0] == i)
        {
            var hi = queries[index++][1];
            maxHeap.Enqueue(hi, -hi);
        }
        nums[i] -= minHeap.Count;
        while (maxHeap.Count != 0 && maxHeap.Peek() >= i && nums[i] > 0)
        {
            var hi = maxHeap.Dequeue();
            minHeap.Enqueue(hi, hi);
            nums[i]--;
            take++;
        }
        if (nums[i] > 0)
            return -1;
        while (minHeap.Count != 0 && minHeap.Peek() <= i)
            minHeap.Dequeue();
    }
    return queries.Length - take;
}