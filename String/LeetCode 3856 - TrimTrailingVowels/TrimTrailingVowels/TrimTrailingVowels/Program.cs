string TrimTrailingVowels(string s)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var res = "";
    var found = false;
    for (int i = s.Length - 1; i >= 0; i--)
    {
        if (!vowels.Contains(s[i]) || found)
        {
            found = true;
            res = s[i] + res;
        }
    }
    return res;
}