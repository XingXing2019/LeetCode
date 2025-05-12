var s = "successes";
Console.WriteLine(MaxFreqSum(s));

int MaxFreqSum(string s)
{
    var freq = new int[26];
    foreach (var l in s)
        freq[l - 'a']++;
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    int vowel = 0, consonant = 0;
    for (int i = 0; i < freq.Length; i++)
    {
        if (vowels.Contains((char)(i + 'a')))
            vowel = Math.Max(vowel, freq[i]);
        else
            consonant = Math.Max(consonant, freq[i]);
    }
    return vowel + consonant;
}