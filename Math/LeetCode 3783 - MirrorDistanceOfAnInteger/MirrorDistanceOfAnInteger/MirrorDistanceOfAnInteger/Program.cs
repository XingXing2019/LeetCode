int MirrorDistance(int n)
{
    int copy = n, reversed = 0;
    while (copy != 0)
    {
        reversed = reversed * 10 + copy % 10;
        copy /= 10;
    }
    return Math.Abs(reversed - n);
}