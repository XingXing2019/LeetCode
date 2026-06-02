int FirstMatchingIndex(string s)
{
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == s[s.Length - i - 1])
            return i;
    }
    return -1;
}