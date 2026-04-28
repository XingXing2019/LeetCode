using System.Text;

string SortVowels(string s)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var pos = new Dictionary<char, int>();
    for (int i = s.Length - 1; i >= 0; i--)
        pos[s[i]] = i;
    var freq = s.Where(x => vowels.Contains(x)).GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => pos[x.Key]).ToDictionary(x => x.Key, x => x.Count());
    var letters = new StringBuilder();
    var res = new StringBuilder();
    foreach (var vowel in freq.Keys)
        letters.Append(new string(vowel, freq[vowel]));
    var index = 0;
    foreach (var l in s)
    {
        if (vowels.Contains(l))
            res.Append(letters[index++]);
        else
            res.Append(l);
    }
    return res.ToString();
}