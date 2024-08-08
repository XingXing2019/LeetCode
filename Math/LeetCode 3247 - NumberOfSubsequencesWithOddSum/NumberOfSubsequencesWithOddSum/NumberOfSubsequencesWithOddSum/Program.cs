int SubsequenceCount(int[] nums)
{
    long mod = 1_000_000_000 + 7;
    return nums.All(x => x % 2 == 0) ? 0 : (int)Pow(2, nums.Length - 1, mod);
}

long Pow(long a, long b, long mod)
{
    if (b == 0) return 1;
    var pow = Pow(a, b / 2, mod);
    return b % 2 == 0 ? pow * pow % mod : pow * pow * a % mod;
}