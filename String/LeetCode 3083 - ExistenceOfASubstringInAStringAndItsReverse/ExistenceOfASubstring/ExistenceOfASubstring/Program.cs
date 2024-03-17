bool IsSubstringPresent(string s)
{
    var substrings = new HashSet<string>();
    for (int i = 0; i <= s.Length - 2; i++)
        substrings.Add(s.Substring(i, 2));
    s = string.Join("", s.Reverse());
    for (int i = 0; i <= s.Length - 2; i++)
    {
        if (!substrings.Contains(s.Substring(i, 2))) continue;
        return true;
    }
    return false;
}