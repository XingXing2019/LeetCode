int MinAllOneMultiple(int k)
{
    if (k % 2 == 0) return -1;
    int reminder = 0, res = 0;
    for (int i = 0; i < k; i++)
    {
        reminder = (reminder * 10 + 1) % k;
        res++;
        if (reminder == 0)
        {
            return res;
        }
    }
    return -1;
}