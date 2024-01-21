int MinimumPushes(string word)
{
    var freq = word.GroupBy(x => x).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
    int res = 0, times = 1, count = 0;
    foreach (var letter in freq.Keys)
    {
        res += times * freq[letter];
        count++;
        if (count != 8) continue;
        times++;
        count = 0;
    }
    return res;
}