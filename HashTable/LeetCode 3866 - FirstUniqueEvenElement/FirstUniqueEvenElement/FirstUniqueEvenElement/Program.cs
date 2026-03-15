int FirstUniqueEven(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % 2 != 0 || freq[nums[i]] > 1) continue;
        return nums[i];
    }
    return -1;
}