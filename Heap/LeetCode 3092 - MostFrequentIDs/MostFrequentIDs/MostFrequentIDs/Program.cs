int[] nums = { 2, 3, 2, 1 };
int[] freq = { 3, 2, -3, 1 };
Console.WriteLine(MostFrequentIDs(nums, freq));

long[] MostFrequentIDs(int[] nums, int[] freq)
{
    var res = new long[nums.Length];
    var dict = new Dictionary<long, long>();
    var heap = new PriorityQueue<long[], long>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = 0;
        dict[nums[i]] += freq[i];
        heap.Enqueue(new[] { dict[nums[i]], nums[i] }, -dict[nums[i]]);
        while (heap.Count != 0 && heap.Peek()[0] != dict[heap.Peek()[1]])
            heap.Dequeue();
        res[i] = heap.Count == 0 ? 0 : heap.Peek()[0];
    }
    return res;
}