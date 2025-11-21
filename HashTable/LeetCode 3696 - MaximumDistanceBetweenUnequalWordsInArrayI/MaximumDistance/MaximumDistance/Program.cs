int MaxDistance(string[] words)
{
    var indexes = new Dictionary<string, List<int>>();
    for (int i = 0; i < words.Length; i++)
    {
        if (!indexes.ContainsKey(words[i]))
            indexes[words[i]] = new List<int>();
        indexes[words[i]].Add(i);
    }
    var res = 0;
    foreach (var word in indexes.Keys)
    {
        int li = indexes[word][0], hi = indexes[word][^1];
        foreach (var other in indexes.Keys)
        {
            if (word == other) continue;
            var dis = Math.Max(Math.Abs(indexes[other][^1] - li), Math.Abs(indexes[other][0] - hi)) + 1;
            res = Math.Max(res, dis);
        }
    }
    return res;
}