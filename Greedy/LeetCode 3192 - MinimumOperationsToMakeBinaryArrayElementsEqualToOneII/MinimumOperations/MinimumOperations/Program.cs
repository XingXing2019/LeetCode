int MinOperations(int[] nums)
{
    var res = 0;
    foreach (var num in nums)
    {
        if (num != res % 2) continue;
        res++;
    }
    return res;
}