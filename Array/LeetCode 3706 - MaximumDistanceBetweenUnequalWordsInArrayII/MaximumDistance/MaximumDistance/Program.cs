int MaxDistance(string[] words)
{
    var res = 0;
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i] == words[^1]) continue;
        res = words.Length - i;
        break;
    }
    for (int i = words.Length - 1; i >= 0; i--)
    {
        if (words[i] == words[0]) continue;
        res = Math.Max(res, i + 1);
    }
    return res;
}