int MaxScore(int[] nums)
{
    var size = nums.Length % 2 == 0 ? 2 : 1;
    int sum = 0, window = 0;
    for (int i = 0; i < size; i++)
    {
        sum += nums[i];
        window += nums[i];
    }
    var left = window;
    for (int i = size; i < nums.Length; i++)
    {
        sum += nums[i];
        window += nums[i];
        window -= nums[i - size];
        left = Math.Min(left, window);
    }
    return sum - left;
}