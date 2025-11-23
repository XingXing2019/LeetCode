var n = 3;
var target = 0L;
Console.WriteLine(LexSmallestNegatedPerm(n, target));

int[] LexSmallestNegatedPerm(int n, long target)
{
    var res = new int[n];
    int li = 0, hi = n - 1;
    long total = (long)n * (n + 1) / 2;
    if (total < Math.Abs(target) || total % 2 != Math.Abs(target) % 2)
        return new int[0];
    for (int i = n; i >= 1; i--)
    {
        if (target + i <= (long)i * (i - 1) / 2)
        {
            res[li++] = -i;
            target += i;
        }
        else
        {
            res[hi--] = i;
            target -= i;
        }
    }
    return res;
}