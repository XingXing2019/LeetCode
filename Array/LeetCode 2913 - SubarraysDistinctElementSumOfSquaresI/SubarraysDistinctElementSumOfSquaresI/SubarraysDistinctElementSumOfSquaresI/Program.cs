var nums = new List<int> { 1, 2, 1 };
Console.WriteLine(SumCounts(nums));

int SumCounts(IList<int> nums)
{
    var res = 0;
    for (int i = 1; i <= nums.Count; i++)
        res += GetSquare(nums, i);
    return res;
}

int GetSquare(IList<int> nums, int len)
{
    var freq = new Dictionary<int, int>();
    int index = 0, res = 0;
    while (index < len)
    {
        if (!freq.ContainsKey(nums[index]))
            freq[nums[index]] = 0;
        freq[nums[index++]]++;
    }
    while (index < nums.Count)
    {
        res += freq.Count * freq.Count;
        if (!freq.ContainsKey(nums[index]))
            freq[nums[index]] = 0;
        freq[nums[index]]++;
        freq[nums[index - len]]--;
        if (freq[nums[index - len]] == 0)
            freq.Remove(nums[index - len]);
        index++;
    }
    return res + freq.Count * freq.Count;
}