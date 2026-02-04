var n = 1;
Console.WriteLine(CountMonobit(n));

int CountMonobit(int n)
{
    var res = 0;
    for (int i = 0; i <= n; i++)
    {
        if (!IsMonobit(i)) continue;
        res++;
    }
    return res;
}

bool IsMonobit(int num)
{
    if (num == 0) return true;
    int one = 0, zero = 0;
    while (num != 0)
    {
        if (num % 2 == 0)
            zero++;
        else
            one++;
        num >>= 1;
    }
    return one == 0 || zero == 0;
}