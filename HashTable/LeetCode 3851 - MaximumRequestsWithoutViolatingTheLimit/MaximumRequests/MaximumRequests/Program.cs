int[][] requests = new[]
{
    new[] { 11, 2 },
    new[] { 11, 2 },
    new[] { 11, 5 },
    new[] { 11, 6 },
};
Console.WriteLine(MaxRequests(requests, 2, 5));

int MaxRequests(int[][] requests, int k, int window)
{
    var dict = requests.GroupBy(x => x[0]).ToDictionary(x => x.Key, x => x.OrderBy(x => x[1]).Select(x => x[1]).ToList());
    var res = 0;
    foreach (var times in dict.Values)
        res += Count(times, window, k);
    return requests.Length - res;
}

int Count(List<int> times, int window, int k)
{
    var count = 0;
    for (int i = 0; i < times.Count; i++)
    {
        var index = BinarySearch(times, i, times[i] + window);
        count += Math.Max(0, index - k - i + 1);
    }
    return count;
}

int BinarySearch(List<int> times, int li, int target)
{
    var hi = times.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (times[mid] <= target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}