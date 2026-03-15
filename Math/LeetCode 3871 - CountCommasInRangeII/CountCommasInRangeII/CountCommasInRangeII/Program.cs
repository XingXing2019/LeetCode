var n = 1236;
Console.WriteLine(CountCommas(n));

long CountCommas(long n)
{
    if (n < 1000) return 0;
    var res = 0L;
    var nums = new long[] { 1_000, 1_000_000, 1_000_000_000, 1_000_000_000_000, 1_000_000_000_000_000, 1_000_000_000_000_000_000 };
    for (int i = 1; i <= 5; i++)
    {
        var hi = Math.Min(n, nums[i] - 1);
        var li = nums[i - 1];
        res += Math.Max(0, hi - li + 1) * i;
    }
    return res;
}