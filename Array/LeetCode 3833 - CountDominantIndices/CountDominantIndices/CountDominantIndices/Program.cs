int[] nums = { 58, 89 };
Console.WriteLine(DominantIndices(nums));

int DominantIndices(int[] nums)
{
    var res = 0;
    var suffix = new int[nums.Length];
    for (int i = nums.Length - 1; i >= 0; i--)
        suffix[i] = i == nums.Length - 1 ? 0 : nums[i + 1] + suffix[i + 1];
    for (int i = 0; i < nums.Length; i++)
    {
        var len = nums.Length - i - 1;
        if (nums[i] * len <= suffix[i]) continue;
        res++;
    }
    return res;
}