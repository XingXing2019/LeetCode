int[] nums = { 10, 8, 18, 9 };
int k = 3, dist = 1;
Console.WriteLine(MinimumCost(nums, k, dist));

long MinimumCost(int[] nums, int k, int dist)
{
    var minHeap = new SortedDictionary<int, int>();
    var maxHeap = new SortedDictionary<int, int>();
    int count = 0;
    long res = 0L, sum = 0L;
    for (int i = 1; i < dist + 2; i++)
    {
        if (!maxHeap.ContainsKey(nums[i]))
            maxHeap[nums[i]] = 0;
        maxHeap[nums[i]]++;
        count++;
        var max = count > k - 1 ? maxHeap.Keys.Last() : 0;
        if (count > k - 1)
        {
            maxHeap[max]--;
            if (maxHeap[max] == 0)
                maxHeap.Remove(max);
            if (!minHeap.ContainsKey(max))
                minHeap[max] = 0;
            minHeap[max]++;
            count--;
        }
        sum += nums[i] - max;
        res = sum;
    }
    for (int i = dist + 2; i < nums.Length; i++)
    {
        int add = nums[i], remove = nums[i - dist - 1];
        if (maxHeap.ContainsKey(remove))
        {
            maxHeap[remove]--;
            count--;
            if (maxHeap[remove] == 0)
                maxHeap.Remove(remove);
            sum -= remove;
        }
        else
        {
            minHeap[remove]--;
            if (minHeap[remove] == 0)
                minHeap.Remove(remove);
        }
        if (!maxHeap.ContainsKey(nums[i]))
            maxHeap[nums[i]] = 0;
        maxHeap[nums[i]]++;
        count++;
        var max = count > k - 1 ? maxHeap.Keys.Last() : 0;
        if (count > k - 1)
        {
            maxHeap[max]--;
            if (maxHeap[max] == 0)
                maxHeap.Remove(max);
            if (!minHeap.ContainsKey(max))
                minHeap[max] = 0;
            minHeap[max]++;
            count--;
        }
        sum += nums[i] - max;
        var min = minHeap.Keys.Any() ? minHeap.Keys.First() : int.MaxValue;
        max = maxHeap.Keys.Last();
        if (max > min)
        {
            maxHeap[max]--;
            if (maxHeap[max] == 0)
                maxHeap.Remove(max);
            minHeap[min]--;
            if (minHeap[min] == 0)
                minHeap.Remove(min);
            if (!maxHeap.ContainsKey(min))
                maxHeap[min] = 0;
            maxHeap[min]++;
            if (!minHeap.ContainsKey(max))
                minHeap[max] = 0;
            minHeap[max]++;
            sum += min - max;
        }
        res = Math.Min(res, sum);
    }
    return res + nums[0];
}