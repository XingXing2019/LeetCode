int CountWays(IList<int> nums)
{
    nums = nums.OrderBy(x => x).ToList();
    nums.Add(int.MaxValue);
    var res = nums[0] != 0 ? 1 : 0;
    for (int i = 0; i < nums.Count; i++)
    {
        if (i + 1 > nums[i] && i + 1 < nums[i + 1])
            res++;
    }
    return res;
}