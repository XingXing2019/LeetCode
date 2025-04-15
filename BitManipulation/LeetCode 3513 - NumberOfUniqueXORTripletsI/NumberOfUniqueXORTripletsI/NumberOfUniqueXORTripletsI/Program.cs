int UniqueXorTriplets(int[] nums)
{
    var n = nums.Length;
    if (n < 3) return n;
    var msb = GetMsb(n);
    return (int)Math.Pow(2, (double)msb + 1);
}

int GetMsb(int n)
{
    var res = 0;
    while (n != 0)
    {
        res++;
        n >>= 1;
    }
    return res - 1;
}