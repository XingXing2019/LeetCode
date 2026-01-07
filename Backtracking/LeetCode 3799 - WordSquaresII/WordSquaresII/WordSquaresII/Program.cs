IList<IList<string>> WordSquares(string[] words)
{
    words = words.OrderBy(x => x).ToArray();
    var res = new List<IList<string>>();
    DFS(words, new List<string>(), res);
    return res;
}

void DFS(string[] words, List<string> combo, IList<IList<string>> res)
{
    if (combo.Count == 4)
    {
        res.Add(new List<string>(combo));
        return;
    }
    foreach (var word in words)
    {
        if (combo.Contains(word)) continue;
        if (combo.Count == 1 && combo[0][0] != word[0]) continue;
        if (combo.Count == 2 && combo[0][3] != word[0]) continue;
        if (combo.Count == 3 && (combo[1][3] != word[0] || combo[2][3] != word[3])) continue;
        combo.Add(word);
        DFS(words, combo, res);
        combo.RemoveAt(combo.Count - 1);
    }
}