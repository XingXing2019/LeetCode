int VowelConsonantScore(string s)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    int v = 0, c = 0;
    foreach (var l in s)
    {
        if (!char.IsLetter(l)) continue;
        if (vowels.Contains(l))
            v++;
        else
            c++;
    }
    return c == 0 ? 0 : v / c;
}