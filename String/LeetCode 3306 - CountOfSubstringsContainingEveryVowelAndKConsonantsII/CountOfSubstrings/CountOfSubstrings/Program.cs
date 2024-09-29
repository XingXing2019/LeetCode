var word = "aoaiuefi";
var k = 1;
Console.WriteLine(CountOfSubstrings(word, k));

long CountOfSubstrings(string word, int k)
{
    return Count(word, k) - Count(word, k + 1);
}

long Count(string word, int k)
{
    var freq = new Dictionary<char, int>();
    int li = 0, hi = 0;
    var res = 0L;
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    while (hi < word.Length)
    {
        if (vowels.Contains(word[hi]))
            freq[word[hi]] = freq.GetValueOrDefault(word[hi], 0) + 1;
        else
            k--;
        while (k <= 0 && freq.Count == 5 && freq.All(x => x.Value > 0))
        {
            res += word.Length - hi;
            if (vowels.Contains(word[li]))
                freq[word[li]]--;
            else
                k++;
            li++;
        }
        hi++;
    }
    return res;
}