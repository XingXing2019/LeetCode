int BeautifulSubstrings(string s, int k)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var counts = new int[s.Length];
    var res = 0;
    for (int i = 0; i < s.Length; i++)
    {
        var vowel = vowels.Contains(s[i]) ? 1 : 0;
        counts[i] = i == 0 ? 0 + vowel : counts[i - 1] + vowel;
    }
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i + 1; j < s.Length; j++)
        {
            var vowel = i == 0 ? counts[j] : counts[j] - counts[i - 1];
            var consonant = j - i + 1 - vowel;
            if (vowel != consonant || vowel * consonant % k != 0) continue;
            res++;
        }
    }
    return res;
}