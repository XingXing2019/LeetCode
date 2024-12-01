int SmallestNumber(int n)
{
    var res = 1;
    while (res < n)
        res = (res << 1) + 1;
    return res;
}