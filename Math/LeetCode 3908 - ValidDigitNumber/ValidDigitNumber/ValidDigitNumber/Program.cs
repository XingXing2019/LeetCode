int n = 107, x = 7;
Console.WriteLine(ValidDigit(n, x));

bool ValidDigit(int n, int x)
{
    var has = false;
    while (n / 10 != 0)
    {
        has |= n % 10 == x;
        n /= 10;
    }
    return has && n != x;
}