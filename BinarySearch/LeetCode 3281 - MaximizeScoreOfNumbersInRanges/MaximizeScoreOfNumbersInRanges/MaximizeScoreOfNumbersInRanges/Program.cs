int[] start = { 0, 9, 2, 9 };
var d = 2;
Console.WriteLine(MaxPossibleScore(start, d));

int MaxPossibleScore(int[] start, int d)
{
    Array.Sort(start);
    long li = 0, hi = start[^1] + d;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (IsValid(start, d, mid))
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return (int)hi;
}

bool IsValid(int[] start, long d, long x)
{
    long min = start[0];
    for (int i = 0; i < start.Length - 1; i++)
    {
        if (min + x > start[i + 1] + d)
            return false;
        min = Math.Max(min + x, start[i + 1]);
    }
    return true;
}