int GenerateKey(int num1, int num2, int num3)
{
    int res = 0, pow = 1;
    while (num1 * num2 * num3 != 0)
    {
        var digit = Math.Min(num1 % 10, Math.Min(num2 % 10, num3 % 10));
        res += pow * digit;
        num1 /= 10;
        num2 /= 10;
        num3 /= 10;
        pow *= 10;
    }
    return res;
}