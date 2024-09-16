var n = 1;
Console.WriteLine(NextBeautifulNumber(n));

int NextBeautifulNumber(int n)
{
    while (true)
    {
        if (IsValid(++n))
            return n;
    }
}

bool IsValid(int n)
{
    var digits = new int[10];
    while (n != 0)
    {
        digits[n % 10]++;
        n /= 10;
    }
    for (int i = 0; i < digits.Length; i++)
    {
        if (digits[i] == 0) continue;
        if (digits[i] != i)
            return false;
    }
    return true;
}