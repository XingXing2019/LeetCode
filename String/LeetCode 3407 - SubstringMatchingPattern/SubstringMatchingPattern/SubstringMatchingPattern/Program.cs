bool HasMatch(string s, string p)
{
    var parts = p.Split('*', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 0)
        return true;
    if (parts.Length == 1)
        return s.Contains(parts[0]);
    for (int i = 1; i <= s.Length; i++)
    {
        var front = s.Substring(0, i);
        var back = s.Substring(i);
        if (front.Contains(parts[0]) && back.Contains(parts[1]))
            return true;
    }
    return false;
}