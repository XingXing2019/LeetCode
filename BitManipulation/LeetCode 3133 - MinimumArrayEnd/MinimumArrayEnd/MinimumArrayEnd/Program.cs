int n = 2, x = 7;
Console.WriteLine(MinEnd(n, x));

long MinEnd(int n, int x)
{
    long res = x;
    n--;
    for (int i = 0; i < 64 && n != 0; i++)
    {
        if ((x & 1) == 0)
        {
            if ((n & 1) == 1)
                res += 1L << i;
            n >>= 1;
        }
        x >>= 1;
    }
    return res;
}