long SumAndMultiply(int n)
{
    long x = 0, sum = 0, pow = 1;
    while (n != 0)
    {
        var mod = n % 10;
        if (mod != 0)
        {
            sum += mod;
            x += mod * pow;
            pow *= 10;
        }
        n /= 10;
    }
    return x * sum;
}