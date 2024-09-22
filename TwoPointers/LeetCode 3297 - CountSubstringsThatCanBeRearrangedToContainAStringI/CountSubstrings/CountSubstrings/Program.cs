var word1 = "bb";
var word2 = "b";
Console.WriteLine(ValidSubstringCount(word1, word2));
long ValidSubstringCount(string word1, string word2)
{
    int li = 0, hi = 0;
    long res = 0;
    var freq = new int[26];
    foreach (var l in word2)
        freq[l - 'a']++;
    while (hi < word1.Length)
    {
        freq[word1[hi] - 'a']--;
        while (freq.All(x => x <= 0) && li <= hi)
        {
            res += word1.Length - hi;
            freq[word1[li++] - 'a']++;
        }
        hi++;
    }
    return res;
}