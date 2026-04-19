int FirstStableIndex(int[] nums, int k)
{
    int[] prefix = new int[nums.Length];
    int[] suffix = new int[nums.Length];
    int min = int.MaxValue, max = int.MinValue;
    for (int i = 0; i < nums.Length; i++)
    {
        max = Math.Max(max, nums[i]);
        min = Math.Min(min, nums[^(i + 1)];
        prefix[i] = max;
        suffix[^(i + 1)] = min;
    }
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var score = prefix[i] - suffix[i];
        if (score > k) continue;
        res++;
    }
    return res;
}