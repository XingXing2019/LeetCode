int MinimumPushes(string word)
{
    int len = word.Length, res = 0, times = 1;
    while (len > 0)
    {
        res += len > 8 ? 8 * times : len * times;
        len -= 8;
        times++;
    }
    return res;
}