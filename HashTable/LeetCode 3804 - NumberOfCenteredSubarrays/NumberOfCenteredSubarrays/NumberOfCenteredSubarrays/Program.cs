int CenteredSubarrays(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var set = new HashSet<int>();
        var sum = 0;
        for (int j = i; j < nums.Length; j++)
        {
            sum += nums[j];
            set.Add(nums[j]);
            if (!set.Contains(sum)) continue;
            res++;
        }
    }
    return res;
}