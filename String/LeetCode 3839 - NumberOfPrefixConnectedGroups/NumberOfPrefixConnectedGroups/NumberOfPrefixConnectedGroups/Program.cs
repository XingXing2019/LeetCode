int PrefixConnected(string[] words, int k)
{
    var dict = new Dictionary<string, int>();
    foreach (var word in words)
    {
        if (word.Length < k) continue;
        var prefix = word.Substring(0, k);
        if (!dict.ContainsKey(prefix))
            dict[prefix] = 0;
        dict[prefix]++;
    }
    return dict.Where(x => x.Value != 1).ToList().Count;
}