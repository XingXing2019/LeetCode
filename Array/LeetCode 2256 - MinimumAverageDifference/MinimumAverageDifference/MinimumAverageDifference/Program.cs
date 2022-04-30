int[] nums = { 2, 5, 3, 9, 5, 3 };
Console.WriteLine(MinimumAverageDifference(nums));

int MinimumAverageDifference(int[] nums)
{
    var res = 0;
    long min = int.MaxValue;
    var prefix = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    for (int i = 0; i < prefix.Length; i++)
    {
        var avg = Math.Abs(prefix[i] / (i + 1) - (i == prefix.Length - 1 ? 0 : (prefix[^1] - prefix[i]) / (prefix.Length - i - 1)));
        if (min <= avg) continue;
        min = avg;
        res = i;
    }
    return res;
}