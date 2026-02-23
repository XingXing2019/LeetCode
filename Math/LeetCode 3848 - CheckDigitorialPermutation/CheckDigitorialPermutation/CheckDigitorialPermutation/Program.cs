bool IsDigitorialPermutation(int n)
{
    int sum = 0, copy = n;
    var digits = new int[10];
    while (copy != 0)
    {
        var mod = copy % 10;
        digits[mod]++;
        sum += GetFactorial(mod);
        copy /= 10;
    }
    while (sum != 0)
    {
        var mod = sum % 10;
        digits[mod]--;
        sum /= 10;
    }
    return digits.All(x => x == 0);
}

int GetFactorial(int n)
{
    var res = 1;
    for (int i = 1; i <= n; i++)
        res *= i;
    return res;
}