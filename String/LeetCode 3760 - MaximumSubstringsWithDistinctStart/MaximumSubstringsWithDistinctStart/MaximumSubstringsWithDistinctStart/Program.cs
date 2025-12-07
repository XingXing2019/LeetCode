int MaxDistinct(string s)
{
    var set = new HashSet<char>(s.ToCharArray());
    return set.Count;
}