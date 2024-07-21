int MinChanges(int n, int k)
{
    var res = 0;
    while (n != 0 || k != 0)
    {
        if (n % 2 != k % 2)
            res++;
        n >>= 1;
        k >>= 1;
    }
    return res;
}