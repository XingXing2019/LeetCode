IList<string> ValidStrings(int n)
{
    var res = new List<string>();
    DFS(n, "", res);
    return res;
}

void DFS(int n, string s, List<string> res)
{
    if (s.Length == n)
    {
        res.Add(s);
        return;
    }
    if (s.Length == 0 || s[^1] == '1')
        DFS(n, s + '0', res);
    DFS(n, s + '1', res);
}