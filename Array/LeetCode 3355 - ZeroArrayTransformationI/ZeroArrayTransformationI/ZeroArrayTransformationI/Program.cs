bool IsZeroArray(int[] nums, int[][] queries)
{
    var dict = new Dictionary<int, int>();
    foreach (var query in queries)
    {
        int li = query[0], hi = query[1] + 1;
        dict[li] = dict.GetValueOrDefault(li, 0) - 1;
        dict[hi] = dict.GetValueOrDefault(hi, 0) + 1;
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