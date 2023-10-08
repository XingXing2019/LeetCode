int DifferenceOfSums(int n, int m)
{
    var res = 0;
    for (int i = 1; i <= n; i++)
        res += i % m != 0 ? i : -i;
    return res;
}