int[] nums = { 2, 0, 2 };
int[][] queries = new int[][]
{
    new[] { 0, 2, 1 },
    new[] { 0, 2, 1 },
    new[] { 1, 1, 3 },
};
Console.WriteLine(MinZeroArray(nums, queries));

int MinZeroArray(int[] nums, int[][] queries)
{
    int li = 0, hi = queries.Length;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (CanAchieve(nums, queries, mid))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li > queries.Length ? -1 : li;
}

bool CanAchieve(int[] nums, int[][] queries, int len)
{
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < len; i++)
    {
        int li = queries[i][0], hi = queries[i][1] + 1, val = queries[i][2];
        dict[li] = dict.GetValueOrDefault(li, 0) - val;
        dict[hi] = dict.GetValueOrDefault(hi, 0) + val;
    }
    var diff = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        diff += dict.GetValueOrDefault(i, 0);
        if (nums[i] + diff > 0)
            return false;
    }
    return true;
}