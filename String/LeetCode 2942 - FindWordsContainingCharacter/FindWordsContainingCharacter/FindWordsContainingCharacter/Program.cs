IList<int> FindWordsContaining(string[] words, char x)
{
    var res = new List<int>();
    for (int i = 0; i < words.Length; i++)
    {
        if (!words[i].Contains(x)) continue;
        res.Add(i);
    }
    return res;
}