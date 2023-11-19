long MinimumSteps(string s)
{
    int li = 0, hi = s.Length - 1;
    long res = 0;
    while (li < hi)
    {
        if (s[li] != '1')
            li++;
        else if (s[hi] != '0')
            hi--;
        else
        {
            res += hi - li;
            li++;
            hi--;
        }
    }
    return res;
}