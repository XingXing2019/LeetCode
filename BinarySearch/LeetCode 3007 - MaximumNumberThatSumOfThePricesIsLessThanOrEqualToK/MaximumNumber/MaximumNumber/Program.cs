long k = 9;
var x = 1;
Console.WriteLine(FindMaximumNumber(k, x));
long FindMaximumNumber(long k, int x)
{
    long li = 1, hi = (long)1e15;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (GetPrice(mid + 1, x) <= k)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}

long GetPrice(long num, int x)
{
    long count = 0;
    for (int b = x - 1; b < 60; b += x)
    {
        var fullCycles = num / (1L << (b + 1));
        count += fullCycles * (1L << b);
        var remaining = num % (1L << (b + 1));
        count += Math.Max(0, remaining - (1L << b));
    }
    return count;
}