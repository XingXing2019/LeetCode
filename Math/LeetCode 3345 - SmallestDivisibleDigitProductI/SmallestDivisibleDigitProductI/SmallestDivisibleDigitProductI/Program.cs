int SmallestNumber(int n, int t)
{
    for (int i = n; i < int.MaxValue; i++)
    {
        if (GetProduct(i) % t == 0)
            return i;
    }
    return -1;
}

int GetProduct(int n)
{
    var res = 1;
    while (n != 0)
    {
        res *= n % 10;
        n /= 10;
    }
    return res;
}