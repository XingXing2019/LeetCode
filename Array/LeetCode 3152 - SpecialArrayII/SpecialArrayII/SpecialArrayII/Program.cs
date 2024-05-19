int[] nums = { 1, 0, 1, 0, 1, 1 };
int[][] queries = new[]
{
    new[] { 0, 2 },
    new[] { 2, 3 },
};
Console.WriteLine(IsArraySpecial(nums, queries));

bool[] IsArraySpecial(int[] nums, int[][] queries)
{
    var res = new bool[queries.Length];
    int li = 0, hi = 1;
    var dict = new Dictionary<int, int[]>();
    var starts = new List<int>();
    while (hi < nums.Length)
    {
        while (hi < nums.Length && nums[hi] % 2 != nums[hi - 1] % 2)
            hi++;
        dict[li] = new[] { li, hi - 1 };
        starts.Add(li);
        li = hi;
        hi++;
    }
    if (li < nums.Length)
    {
        dict[li] = new[] { li, hi - 1 };
        starts.Add(li);
    }
    for (int i = 0; i < queries.Length; i++)
    {
        int start = queries[i][0], end = queries[i][1];
        var index = starts.BinarySearch(start);
        start = index < 0 ? starts[~index - 1] : starts[index];
        res[i] = dict[start][1] >= end;
    }
    return res;
}