string ConcatHex36(int n)
{
    int n2 = n * n, n3 = n * n * n;
    return GetBase(n2, 16) + GetBase(n3, 36);
}

string GetBase(int n, int baseNum)
{
    var res = "";
    while (n != 0)
    {
        var mod = n % baseNum;
        if (mod < 10)
            res = mod + res;
        else
        {
            mod -= 10;
            res = (char)(mod + 'A') + res;
        }
        n /= baseNum;
    }
    return res;
}