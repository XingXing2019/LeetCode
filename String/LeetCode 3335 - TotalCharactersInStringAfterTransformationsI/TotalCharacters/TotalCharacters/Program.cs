var s = "azbk";
var t = 1;
Console.WriteLine(LengthAfterTransformations(s, t));

int LengthAfterTransformations(string s, int t)
{
    long res = 0, mod = 1_000_000_000 + 7;
    long[] freq = new long[26];
    foreach (var l in s)
        freq[l - 'a']++;
    for (int i = 0; i < t; i++)
    {
        var copy = new long[26];
        for (int j = 0; j <= 25; j++)
        {
            if (freq[j] == 0) continue;
            if (j == 25)
                copy[1] = (copy[1] + freq[j]) % mod;
            copy[(j + 1) % 26] = (copy[(j + 1) % 26] + freq[j]) % mod;;
        }
        freq = copy;
    }
    for (int i = 0; i < 26; i++)
        res = (res + freq[i]) % mod;
    return (int)res;
}