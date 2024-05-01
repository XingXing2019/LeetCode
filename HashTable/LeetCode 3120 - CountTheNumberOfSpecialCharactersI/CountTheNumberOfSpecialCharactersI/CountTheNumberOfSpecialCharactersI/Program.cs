int NumberOfSpecialChars(string word)
{
    var upper = new int[26];
    var lower = new int[26];
    foreach (var l in word)
    {
        if (char.IsUpper(l))
            upper[l - 'A']++;
        else
            lower[l - 'a']++;
    }
    var res = 0;
    for (int i = 0; i < 26; i++)
    {
        if (upper[i] * lower[i] == 0) continue;
        res++;
    }
    return res;
}