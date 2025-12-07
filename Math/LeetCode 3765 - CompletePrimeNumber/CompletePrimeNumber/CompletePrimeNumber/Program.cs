var num = 73;
Console.WriteLine(CompletePrime(num));

bool CompletePrime(int num)
{
    int prefix = 0, suffix = 0, pow = 1;
    var str = num.ToString();
    for (int i = 0; i < str.Length; i++)
    {
        prefix = prefix * 10 + str[i] - '0';
        if (!IsPrime(prefix)) return false;
        suffix += (str[^(i + 1)] - '0') * pow;
        pow *= 10;
        if (!IsPrime(suffix)) return false;
    }
    return true;
}

bool IsPrime(int num)
{
    if (num == 1) return false;
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i != 0) continue;
        return false;
    }
    return true;
}