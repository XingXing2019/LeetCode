var s = "2523533";
Console.WriteLine(FindValidPair(s));

string FindValidPair(string s)
{
    var freq = new int[10];
    foreach (var l in s)
        freq[l - '0']++;
    for (int i = 1; i < s.Length; i++)
    {
        if (s[i] == s[i - 1] || freq[s[i] - '0'] != s[i] - '0' || freq[s[i - 1] - '0'] != s[i - 1] - '0')
            continue;
        return $"{s[i - 1]}{s[i]}";
    }
    return "";
}
