int l = 8, r = 30, k = 2;
Console.WriteLine(CountKthRoots(l, r, k));

int CountKthRoots(int l, int r, int k)
{
    if (k == 1) return r - l + 1;
    var res = 0;
    for (int i = 0; i <= r; i++)
    {
        var pow = GetPow(i, k, r);
        if (pow >= l && pow <= r)
            res++;
        else if (pow > r)
            return res;
    }
    return res;
}

int GetPow(int num, int k, int r)
{
    var res = 1;
    for (int i = 0; i < k; i++)
    {
        res *= num;
        if (res > r) return int.MaxValue;
    }
    return res;
}