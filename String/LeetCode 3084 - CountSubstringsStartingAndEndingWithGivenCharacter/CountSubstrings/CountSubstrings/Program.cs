long CountSubstrings(string s, char c)
{
    var count = s.Count(x => x == c);
    return ((long)count + 1) * count / 2;
}