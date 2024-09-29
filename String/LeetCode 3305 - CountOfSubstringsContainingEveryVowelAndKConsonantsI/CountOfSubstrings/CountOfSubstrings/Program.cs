var word = "ieaouqqieaou";
var k = 1;
Console.WriteLine(CountOfSubstrings(word, k));

int CountOfSubstrings(string word, int k)
{
    var vowel = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var res = 0;
    for (int i = 0; i < word.Length; i++)
    {
        var dict = new Dictionary<char, int>();
        var count = k;
        for (int j = i; j < word.Length; j++)
        {
            if (vowel.Contains(word[j]))
            {
                if (!dict.ContainsKey(word[j]))
                    dict[word[j]] = 0;
                dict[word[j]]++;
            }
            else
                count--;
            if (count == 0 && dict.Count == 5)
                res++;
        }
    }
    return res;
}