var word = "agigie";
var k = 2;
Console.WriteLine(CountCompleteSubstrings(word, k));

int CountCompleteSubstrings(string word, int k)
{
    int res = 0, li = 0, hi = 0;
    var parts = new List<string>();
    while (hi < word.Length)
    {
        if (hi != 0 && Math.Abs(word[hi] - word[hi - 1]) > 2)
        {
            parts.Add(word.Substring(li, hi - li));
            li = hi;
        }
        hi++;
    }
    parts.Add(word.Substring(li, hi - li));
    for (int i = 1; i <= 26; i++)
        res += parts.Sum(x => GetCount(x, i * k, k));
    return res;
}

int GetCount(string word, int len, int k)
{
    var res = 0;
    if (word.Length < len) return res;
    var freq = new Dictionary<int, int>();
    for (int i = 0; i < len; i++)
    {
        if (!freq.ContainsKey(word[i]))
            freq[word[i]] = 0;
        freq[word[i]]++;
    }
    if (freq.All(x => x.Value == k))
        res++;
    for (int i = len; i < word.Length; i++)
    {
        freq[word[i - len]]--;
        if (freq[word[i - len]] == 0)
            freq.Remove(word[i - len]);
        if (!freq.ContainsKey(word[i]))
            freq[word[i]] = 0;
        freq[word[i]]++;
        if (freq.All(x => x.Value == k))
            res++;
    }
    return res;
}