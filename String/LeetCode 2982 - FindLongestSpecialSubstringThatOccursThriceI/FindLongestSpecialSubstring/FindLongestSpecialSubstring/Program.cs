int MaximumLength(string s)
{
    var dict = new Dictionary<string, int>();
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i; j < s.Length; j++)
        {
            var str = s.Substring(i, j - i + 1);
            if (!dict.ContainsKey(str))
                dict[str] = 0;
            dict[str]++;
        }
    }
    return dict.Where(x => x.Value >= 3).Max(x => x.Key.Length);
}