int NumberCount(int a, int b)
{
    var res = 0;
    for (int i = a; i <= b; i++)
    {
        if (!IsUniqueDigit(i)) continue;
        res++;
    }
    return res;
}

bool IsUniqueDigit(int n)
{
    var unique = new HashSet<int>();
    while (n != 0)
    {
        if (!unique.Add(n % 10))
            return false;
        n /= 10;
    }
    return true;
}