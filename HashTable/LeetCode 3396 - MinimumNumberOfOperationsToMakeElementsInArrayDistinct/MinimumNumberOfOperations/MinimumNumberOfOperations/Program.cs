int MinimumOperations(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    int res = 0, index = 0;
    while (freq.Any(x => x.Value != 1))
    {
        for (int i = 0; i < 3 && index < nums.Length; i++)
        {
            freq[nums[index]]--;
            if (freq[nums[index]] == 0)
                freq.Remove(nums[index]);
            index++;
        }
        res++;
    }
    return res;
}