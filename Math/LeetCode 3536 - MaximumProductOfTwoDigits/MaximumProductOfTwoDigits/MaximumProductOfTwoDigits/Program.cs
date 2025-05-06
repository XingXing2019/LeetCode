int MaxProduct(int n)
{
    var digits = new List<int>();
    while (n != 0)
    {
        digits.Add(n % 10);
        n /= 10;
    }
    int max = 0, secMax = 0;
    foreach (var digit in digits)
    {
        if (digit > max)
        {
            secMax = max;
            max = digit;
        }
        else if (digit > secMax)
            secMax = digit;
    }
    return max * secMax;
}