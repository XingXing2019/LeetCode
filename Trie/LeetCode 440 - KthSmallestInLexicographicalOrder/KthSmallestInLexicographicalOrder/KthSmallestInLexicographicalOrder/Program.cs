int FindKthNumber(int n, int k)
{
    return DFS(0, n, k);
}

int DFS(int prefix, int n, int k)
{
    if (k == 0) return prefix;
    var start = prefix == 0 ? 1 : 0;
    for (int i = start; i < 10; i++)
    {
        var count = 1 + GetTotal(prefix * 10 + i, n);
        if (count < k)
            k -= count;
        else
            return DFS(prefix * 10 + i, n, k - 1);
    }
    return -1;
}

int GetTotal(long prefix, int n)
{
    var count = 0L;
    var exp = 10L;
    while (true)
    {
        var li = prefix * exp;
        var hi = prefix * exp + exp + 1;
        if (li > n) break;
        if (li <= n && hi >= n)
        {
            count += n - li + 1;
            break;
        }
        else
            count += exp;
        exp *= 10;

    }
    return (int)count;
}