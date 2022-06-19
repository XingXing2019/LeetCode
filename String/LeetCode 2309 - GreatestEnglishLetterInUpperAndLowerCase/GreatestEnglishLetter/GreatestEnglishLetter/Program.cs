string GreatestLetter(string s)
{
    var upper = new bool[26];
    var lower = new bool[26];
    foreach (var l in s)
    {
        if (char.IsUpper(l))
            upper[l - 'A'] = true;
        else
            lower[l - 'a'] = true;
    }
    for (int i = upper.Length - 1; i >= 0; i--)
    {
        if (!upper[i] || !lower[i]) continue;
        return ((char)(i + 'A')).ToString();
    }
    return "";
}