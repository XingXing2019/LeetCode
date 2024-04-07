int[] nums = { 1, 4, 3, 3, 2 };
Console.WriteLine(LongestMonotonicSubarray(nums));

int LongestMonotonicSubarray(int[] nums)
{
    int res = 0, increase = 1, decrease = 1;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] == nums[i - 1])
        {
            res = Math.Max(res, Math.Max(increase, decrease));
            increase = 1;
            decrease = 1;
        }
        else if (nums[i] > nums[i - 1])
        {
            res = Math.Max(res, decrease);
            increase++;
            decrease = 1;
        }
        else
        {
            res = Math.Max(res, increase);
            decrease++;
            increase = 1;
        }
    }
    return Math.Max(res, Math.Max(increase, decrease));
}