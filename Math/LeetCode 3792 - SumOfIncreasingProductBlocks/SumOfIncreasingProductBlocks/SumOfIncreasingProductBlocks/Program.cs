var n = 3;
Console.WriteLine(SumOfBlocks(n));

int SumOfBlocks(int n)
{
    long res = 0, mod = 1_000_000_000 + 7, cur = 0;
    for (int i = 1; i <= n; i++)
    {
        var temp = 1L;
        for (int j = 0; j < i; j++)
        {
            cur++;
            temp = temp * cur % mod;
        }
        res = (res + temp) % mod;
    }
    return (int)(res % mod);
}