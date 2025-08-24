int GcdOfOddEvenSums(int n)
{
    int odd = 0, even = 0;
    for (int i = 1; i <= 2 * n; i++)
    {
        if (i % 2 == 0)
            even += i;
        else
            odd += i;
    }
    return GCD(odd, even);
}

int GCD(int a, int b)
{
    if (a % b == 0) return b;
    return GCD(b, a % b);
}