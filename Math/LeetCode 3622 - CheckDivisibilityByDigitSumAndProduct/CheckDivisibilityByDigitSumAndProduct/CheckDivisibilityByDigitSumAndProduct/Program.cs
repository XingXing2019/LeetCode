bool CheckDivisibility(int n)
{
    var copy = n;
    long sum = 0, product = 1;
    while (copy != 0)
    {
        sum += copy % 10;
        product *= copy % 10;
        copy /= 10;
    }
    return n % (sum + product) == 0;
}