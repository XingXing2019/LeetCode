int[] LimitOccurrences(int[] nums, int k)
{
    var res = new List<int>();
    int count = 0, cur = nums[0];
    foreach (var num in nums)
    {
        if (num == cur)
        {
            count++;
            if (count > k) continue;
            res.Add(cur);
        }
        else
        {
            count = 1;
            cur = num;
            res.Add(cur);
        }
    }
    return res.ToArray();
}