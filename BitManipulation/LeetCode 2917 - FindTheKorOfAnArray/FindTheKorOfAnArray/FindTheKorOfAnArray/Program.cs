int FindKOr(int[] nums, int k)
{
    int cur = 1, res = 0;
    for (int i = 0; i < 32; i++)
    {
        var count;
        foreach (var num in nums)
        {
            if ((cur & num) != cur) continue;
            count++;
        }
        if (count >= k)
            res += cur;
        cur <<= 1;
    }
    return res;
}