IList<int> BeautifulIndices(string s, string a, string b, int k)
{
    var indices1 = FindIndices(s, a);
    var indices2 = FindIndices(s, b);
    var res = new List<int>();
    foreach (var index in indices1)
    {
        var li = indices2.BinarySearch(index - k);
        var hi = indices2.BinarySearch(index + k);
        if (li >= 0 || hi >= 0 || ~li != ~hi)
            res.Add(index);
    }
    return res;
}

List<int> FindIndices(string s, string word)
{
    var res = new List<int>();
    for (int i = 0; i <= s.Length - word.Length; i++)
    {
        if (s.Substring(i, word.Length) != word) continue;
        res.Add(i);
    }
    return res;
}