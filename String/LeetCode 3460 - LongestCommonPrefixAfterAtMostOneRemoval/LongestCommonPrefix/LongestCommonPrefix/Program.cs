int LongestCommonPrefix(string s, string t)
{
    int p1 = 0, p2 = 0, chance = 1, res = 0;
    while (p1 < s.Length && p2 < t.Length)
    {
        if (s[p1] == t[p2])
        {
            res++;
            p2++;
        }
        else if (chance != 0)
            chance--;
        else
            return res;
        p1++;
    }
    return res;
}