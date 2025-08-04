int[] nums = { 1, 2, 4, 6 };
Console.WriteLine(MinJumps(nums));

int MinJumps(int[] nums)
{
    var max = nums.Max();
    var primes = GetPrimes(max);
    var pos = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (!pos.ContainsKey(nums[i]))
            pos[nums[i]] = new List<int>();
        pos[nums[i]].Add(i);
    }
    var dict = new Dictionary<int, List<int>>();
    for (var i = 0; i < nums.Length; i++)
    {
        var num = nums[i];
        if (!primes.Contains(num)) continue;
        if (!dict.ContainsKey(num))
            dict[num] = new List<int>();
        for (int j = 1; j * num <= max; j++)
        {
            if (!pos.ContainsKey(j * num)) continue;
            dict[num].AddRange(pos[j * num].Where(x => x != i));
        }
    }

    var res = 0;
    var queue = new Queue<int>();
    var visited = new HashSet<int> { 0 };
    queue.Enqueue(0);
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            if (cur == nums.Length - 1) return res;
            if (visited.Add(cur + 1))
                queue.Enqueue(cur + 1);
            if (cur != 0 && visited.Add(cur - 1))
                queue.Enqueue(cur - 1);
            if (!dict.ContainsKey(nums[cur])) continue;
            foreach (var next in dict[nums[cur]])
            {
                if (visited.Add(next))
                {
                    queue.Enqueue(next);
                }
            }
        }
        res++;
    }
    return -1;
}

HashSet<int> GetPrimes(int n)
{
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    var res = new HashSet<int>();
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}