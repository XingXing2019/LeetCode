int ResiduePrefixes(string s)
{
    var set = new HashSet<char>();
    var res = 0;
    for (int i = 0; i < s.Length; i++)
    {
        set.Add(s[i]);
        if (set.Count != (i + 1) % 3) continue;
        res++;
    }
    return res;
}