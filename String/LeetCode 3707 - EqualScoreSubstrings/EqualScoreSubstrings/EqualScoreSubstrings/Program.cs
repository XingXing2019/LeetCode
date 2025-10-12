bool ScoreBalance(string s)
{
    var prefix = new int[s.Length];
    for (int i = 0; i < s.Length; i++)
        prefix[i] = i == 0 ? s[i] - 'a' + 1 : prefix[i - 1] + s[i] - 'a' + 1;
    for (int i = 0; i < prefix.Length; i++)
    {
        if (prefix[i] != prefix[^1] - prefix[i]) continue;
        return true;
    }
    return false;
}