int[] OccurrencesOfElement(int[] nums, int[] queries, int x)
{
    var dict = new Dictionary<int, int>();
    var count = 1;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != x) continue;
        dict[count++] = i;
    }
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
        res[i] = dict.GetValueOrDefault(queries[i], -1);
    return res;
}