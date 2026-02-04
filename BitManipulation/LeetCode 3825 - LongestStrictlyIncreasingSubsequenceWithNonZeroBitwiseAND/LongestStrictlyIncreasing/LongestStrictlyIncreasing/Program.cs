int LongestSubsequence(int[] nums)
{
    var res = 0;
    for (int i = 0; i < 32; i++)
    {
        var list = new List<int>();
        foreach (var num in nums)
        {
            if (((num >> i) & 1) == 0) continue;
            if (list.Count == 0 || list[^1] < num)
                list.Add(num);
            else
            {
                var index = list.BinarySearch(num);
                if (index < 0) index = ~index;
                list[index] = num;
            }
        }
        res = Math.Max(res, list.Count);
    }
    return res;
}

