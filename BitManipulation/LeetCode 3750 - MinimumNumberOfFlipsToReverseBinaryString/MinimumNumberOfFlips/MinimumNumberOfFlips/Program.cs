int MinimumFlips(int n)
{
    int flip = 0, copy = n, res = 0;
    while (copy != 0)
    {
        flip = flip * 2 + copy % 2;
        copy /= 2;
    }
    while (flip != 0 || n != 0)
    {
        if (flip % 2 != n % 2)
            res++;
        flip /= 2;
        n /= 2;
    }
    return res;
}