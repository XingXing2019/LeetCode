IList<int> GoodIndices(string s)
{
    var res = new List<int>();
    for (int i = 0; i < s.Length; i++)
    {
        var target = i.ToString();
        if (target != s.Substring(i - target.Length + 1, target.Length)) continue;
        res.Add(i);
    }
    return res;
}