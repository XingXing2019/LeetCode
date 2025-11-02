long MinimumTime(int[] d, int[] r)
{
    long li = 0, hi = long.MaxValue;
    var lcm = r[0] * r[1] / GCD(r[0], r[1]);
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (CanAchieve(mid, lcm, d, r))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li;
}

bool CanAchieve(long time, int lcm, int[] d, int[] r)
{
    return time - time / r[0] >= d[0] && time - time / r[1] >= d[1] && time - time / lcm >= d[0] + d[1];
}

int GCD(int a, int b)
{
    return a % b == 0 ? b : GCD(b, a % b);
}