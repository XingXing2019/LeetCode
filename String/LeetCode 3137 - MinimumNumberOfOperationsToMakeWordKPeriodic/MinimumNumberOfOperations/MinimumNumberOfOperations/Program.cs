int MinimumOperationsToMakeKPeriodic(string word, int k)
{
    var freq = new Dictionary<string, int>();
    var max = 0;
    var substring = "";
    for (int i = 0; i < word.Length; i += k)
    {
        var sub = word.Substring(i, k);
        if (!freq.ContainsKey(sub))
            freq[sub] = 0;
        freq[sub]++;
        if (freq[sub] > max)
        {
            max = freq[sub];
            substring = sub;
        }
    }
    return freq.Where(x => x.Key != substring).Sum(x => x.Value);
}