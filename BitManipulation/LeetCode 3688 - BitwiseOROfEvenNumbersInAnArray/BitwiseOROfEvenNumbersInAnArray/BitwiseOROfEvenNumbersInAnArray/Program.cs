int EvenNumberBitwiseORs(int[] nums)
{
    var res = 0;
    foreach (var num in nums)
    {
        if (num % 2 != 0) continue;
        res |= num;
    }
    return res;
}