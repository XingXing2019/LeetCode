int MinOperations(string s)
{
    var sorted = string.Join("", s.OrderBy(x => x));
    if (s == sorted) return 0;
    if (s.Length == 2) return -1;
    char max = 'a', min = 'z';
    foreach (var l in s)
    {
        if (l > max) max = l;
        if (l < min) min = l;
    }
    return sorted[^1] < min && sorted[0] > max ? 3 : 2;
}