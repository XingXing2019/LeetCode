int CountKeyChanges(string s)
{
    s = s.ToLower();
    var res = 0;
    for (int i = 1; i < s.Length; i++)
    {
        if (s[i] == s[i - 1]) continue;
        res++;
    }
    return res;
}