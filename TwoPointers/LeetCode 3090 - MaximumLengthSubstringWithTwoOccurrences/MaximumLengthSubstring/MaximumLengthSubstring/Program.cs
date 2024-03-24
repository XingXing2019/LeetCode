var s = "bcbbbcba";
Console.WriteLine(MaximumLengthSubstring(s));
int MaximumLengthSubstring(string s)
{
    var freq = new int[26];
    int li = 0, hi = 0, res = 0;
    while (hi < s.Length)
    {
        freq[s[hi] - 'a']++;
        while (li < hi && freq[s[hi] - 'a'] > 2)
            freq[s[li++] - 'a']--;
        res = Math.Max(res, hi - li + 1);
        hi++;
    }
    return res;
}