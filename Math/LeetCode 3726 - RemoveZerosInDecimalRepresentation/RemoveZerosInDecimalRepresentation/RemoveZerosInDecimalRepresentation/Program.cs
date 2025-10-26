long RemoveZeros(long n)
{
    var res = 0L;
    var pow = 1L;
    while (n != 0)
    {
        if (n % 10 != 0)
        {
            res += n % 10 * pow;
            pow *= 10;
        }
        n /= 10;
    }
    return res;
}