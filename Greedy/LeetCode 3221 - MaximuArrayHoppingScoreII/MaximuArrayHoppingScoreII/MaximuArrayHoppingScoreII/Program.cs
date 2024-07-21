int[] nums = { 4, 5, 2, 8, 9, 1, 3 };
Console.WriteLine(MaxScore(nums));

long MaxScore(int[] nums)
{
    var suffix = new long[nums.Length][];
    long max = 0, res = 0, index = nums.Length;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        max = Math.Max(max, nums[i]);
        suffix[i] = new[] { index, max };
        if (nums[i] >= max) index = i;
    }
    index = 0;
    while (index < nums.Length)
    {
        res += suffix[index][1] * (suffix[index][0] - index);
        index = suffix[index][0];
    }
    return res;
}