int CountMajoritySubarrays(int[] nums, int target)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var count = 0;
        for (int j = i; j < nums.Length; j++)
        {
            count += nums[j] == target ? 1 : 0;
            res += count * 2 > j - i + 1 ? 1 : 0;
        }
    }
    return res;
}