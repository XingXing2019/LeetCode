int minOperations(String s)
{
    var freq = new int[26];
    foreach (var l in s)
        freq[l - 'a']++;
    var res = 0;
    for (int i = 1; i < 26; i++)
    {
        if (freq[i] == 0) continue;
        res++;
        var next = i == freq.Length - 1 ? 0 : i + 1;
        freq[next] += freq[i];
    }
    return res;
}