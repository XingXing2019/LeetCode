int NumberOfChild(int n, int k)
{
    k %= (n - 1) * 2;
    return k < n - 1 ? k : n - 1 - (k - n + 1);
}