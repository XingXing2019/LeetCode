IList<string> StringSequence(string target)
{
    var res = new List<string>();
    var cur = "a";
    while (cur != target)
    {
        res.Add(cur);
        if (target.StartsWith(cur))
            cur += "a";
        else
            cur = $"{cur.Substring(0, cur.Length - 1)}{(char)(cur[^1] + 1)}";
    }
    res.Add(cur);
    return res;
}