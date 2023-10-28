int MinChanges(string s)
{
    var res = 0;
    for (int i = 1; i < s.Length; i += 2)
    {
        if (s[i] == s[i - 1]) continue;
        res++;
    }
    return res;
}