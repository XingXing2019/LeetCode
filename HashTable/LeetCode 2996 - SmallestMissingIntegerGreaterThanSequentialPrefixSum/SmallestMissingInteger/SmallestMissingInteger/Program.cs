
int MissingInteger(int[] nums)
{
    var set = new HashSet<int>(nums);
    var sum = nums[0];
    for (int i = 1; i < nums.Length && nums[i] == nums[i - 1] + 1; i++)
        sum += nums[i];
    for (int i = sum; i < sum + 50; i++)
    {
        if (set.Contains(i)) continue;
        return i;
    }
    return -1;
}