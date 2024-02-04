int ReturnToBoundaryCount(int[] nums)
{
    int res = 0, cur = 0;
    foreach (var num in nums)
    {
        cur += num;
        if (cur != 0) continue;
        res++;
    }
    return res;
}