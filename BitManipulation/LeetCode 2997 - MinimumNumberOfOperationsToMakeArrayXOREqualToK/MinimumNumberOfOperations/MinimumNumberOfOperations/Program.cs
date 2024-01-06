int MinOperations(int[] nums, int k)
{
    var res = 0;
    for (int i = 0; i < 32; i++)
    {
        var ones = nums.Count(x => ((x >> i) & 1) == 1);
        res += ((k >> i) & 1) == 1 && ones % 2 == 0 || ((k >> i) & 1) == 0 && ones % 2 != 0 ? 1 : 0;
    }
    return res;
}