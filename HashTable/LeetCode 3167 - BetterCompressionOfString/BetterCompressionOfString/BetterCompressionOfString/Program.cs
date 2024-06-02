string BetterCompression(string compressed)
{
    var freq = new int[26];
    var letter = compressed[0];
    var count = 0;
    foreach (var l in compressed)
    {
        if (char.IsLetter(l))
        {
            freq[letter - 'a'] += count;
            count = 0;
            letter = l;
        }
        else
            count = count * 10 + l - '0';
    }
    freq[letter - 'a'] += count;
    var res = "";
    for (int i = 0; i < freq.Length; i++)
    {
        if (freq[i] == 0) continue;
        res += $"{(char)(i + 'a')}{freq[i]}";
    }
    return res;
}