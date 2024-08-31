string StringHash(string s, int k)
{
    var res = "";
    var l = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i != 0 && i % k == 0)
        {
            res += (char)(l % 26 + 'a');
            l = s[i] - 'a';
        }
        else
            l += s[i] - 'a';
    }
    return res + (char)(l % 26 + 'a');
}