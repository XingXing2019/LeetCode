int[] nums = { 2, 4, 8, 16 };
Console.WriteLine(MaxScore(nums));

long MaxScore(int[] nums)
{
    var res = 0L;
    for (int i = 0; i < nums.Length; i++)
        res = Math.Max(res, Math.Max(GetNum(nums, i, true), GetNum(nums, i, false)));
    return res;
}

long GetNum(int[] nums, int index, bool remove)
{
    var copy = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (i == index && remove) continue;
        copy.Add(nums[i]);
    }
    if (copy.Count == 0) return 0;
    if (copy.Count < 2) return copy[0] * copy[0];
    long gcd = GCD(copy[0], copy[1]), lcm = LCM(copy[0], copy[1]);
    for (int i = 2; i < copy.Count; i++)
    {
        gcd = GCD(gcd, copy[i]);
        lcm = LCM(lcm, copy[i]);
    }
    return gcd * lcm;
}

long GCD(long a, long b)
{
    if (a % b == 0) return b;
    return GCD(b, a % b);
}

long LCM(long a, long b)
{
    var gcd = GCD(a, b);
    return a * b / gcd;
}
