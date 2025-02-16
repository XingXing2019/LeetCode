int SumOfGoodNumbers(int[] nums, int k)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var prev = i - k >= 0 ? nums[i - k] : int.MinValue;
        var post = i + k < nums.Length ? nums[i + k] : int.MinValue;
        if (nums[i] > prev && nums[i] > post)
            res += nums[i];
    }
    return res;
}