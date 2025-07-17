char ProcessStr(string s, long k)
{
    var len = 0L;
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '*') 
            len = Math.Max(0, len - 1);
        else if (s[i] == '#')
            len *= 2;
        else if (char.IsLetter(s[i])) 
            len++;
    }
    if (k >= len) return '.';
    for (int i = s.Length - 1; i >= 0; i--)
    {
        if (s[i] == '*')
            len++;
        else if (s[i] == '#')
        {
            len /= 2;
            k %= len;
        }
        else if (s[i] == '%')
            k = len - 1 - k;
        else
        {
            len--;
            if (k == len) return s[i];
        }
    }
    return '.';
}