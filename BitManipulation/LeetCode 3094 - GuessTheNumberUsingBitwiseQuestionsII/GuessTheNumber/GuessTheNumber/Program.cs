int FindNumber()
{
    int res = 0, start = CommonBits(0);
    CommonBits(0);
    for (int i = 0; i < 31; i++)
    {
        var count = CommonBits(1 << i);
        if (count > start)
            res += 1 << i;
        CommonBits(1 << i);
    }
    return res;
}


int CommonBits(int num)
{
    return 0;
}
