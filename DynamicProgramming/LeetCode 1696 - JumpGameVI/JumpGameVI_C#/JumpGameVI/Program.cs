int MaxResult(int[] nums, int k)
{
    var dp = new int[nums.Length];
    dp[0] = nums[0];
    var queue = new LinkedList<int>();
    queue.AddLast(0);
    for (int i = 1; i < dp.Length; i++)
    {
        while (i - queue.First.Value > k)
            queue.RemoveFirst();
        dp[i] = dp[queue.First.Value] + nums[i];
        while (queue.Count > 0 && dp[i] >= dp[queue.Last.Value])
            queue.RemoveLast();
        queue.AddLast(i);
    }
    return dp[^1];
}

int MaxResult_Heap(int[] nums, int k)
{
    var dp = new int[nums.Length];
    dp[0] = nums[0];
    var maxHeap = new PriorityQueue<int[], int>();
    maxHeap.Enqueue(new []{nums[0], 0}, -nums[0]);
    for (int i = 1; i < dp.Length; i++)
    {
        dp[i] = maxHeap.Peek()[0] + nums[i];
        maxHeap.Enqueue(new []{dp[i], i}, -dp[i]);
        while (maxHeap.Count != 0 && maxHeap.Peek()[1] < i - k)
            maxHeap.Dequeue();
    }
    return dp[^1];
}