int MaxDifference(string s)
{
    var freq = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var odds = freq.Where(x => x.Value % 2 != 0).Select(x => x.Value).OrderBy(x => x).ToList();
    var evens = freq.Where(x => x.Value % 2 == 0).Select(x => x.Value).OrderBy(x => x).ToList();
    return Math.Max(odds[0] - evens[^1], odds[^1] - evens[0]);
}