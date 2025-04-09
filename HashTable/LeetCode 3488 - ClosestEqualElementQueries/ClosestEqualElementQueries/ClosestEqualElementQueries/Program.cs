int[] nums = { 1, 3, 1, 4, 1, 3, 2 };
int[] queries = { 0, 3, 5 };
Console.WriteLine(SolveQueries(nums, queries));

IList<int> SolveQueries(int[] nums, int[] queries)
{
    var dict = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = new List<int>();
        dict[nums[i]].Add(i);
    }
    var res = new List<int>();
    foreach (var query in queries)
    {
        var num = nums[query];
        var indexes = dict[num];
        if (indexes.Count == 1)
            res.Add(-1);
        else
        {
            var index = BinarySearch(indexes, query);
            var before = index == 0 ? nums.Length - indexes[^1] + query : query - indexes[index - 1];
            var after = index == indexes.Count - 1 ? nums.Length - query + indexes[0] : indexes[index + 1] - query;
            res.Add(Math.Min(before, after));
        }
    }
    return res;
}

int BinarySearch(List<int> nums, int target)
{
    int li = 0, hi = nums.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (nums[mid] == target)
            return mid;
        if (nums[mid] < target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return li;
}