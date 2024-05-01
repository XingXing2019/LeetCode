long MaxNumber(long n)
{
    long res = 0;
    var index = 0;
    while (n != 1)
    {
        res += 1L << index;
        index++;
        n >>= 1;
    }
    return res;
}