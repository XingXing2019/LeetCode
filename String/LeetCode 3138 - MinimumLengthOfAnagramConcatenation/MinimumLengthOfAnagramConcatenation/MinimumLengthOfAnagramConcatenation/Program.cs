var s = "cdef";
Console.WriteLine(MinAnagramLength(s));

int MinAnagramLength(string s)
{
    var freq = new int[s.Length][];
    for (int i = 0; i < s.Length; i++)
    {
        freq[i] = new int[26];
        if (i != 0)
            Array.Copy(freq[i - 1], freq[i], 26);
        freq[i][s[i] - 'a']++;
    }
    var lens = new List<int>();
    for (int i = 1; i <= s.Length; i++)
    {
        if (s.Length % i != 0 || !IsValid(freq, i)) continue;
        return i;
    }
    return -1;
}

bool IsValid(int[][] freq, int len)
{
    var letters = freq[len - 1];
    for (int i = 1; i < freq.Length / len; i++)
    {
        var before = freq[i * len - 1];
        var back = freq[(i + 1) * len - 1];
        for (int j = 0; j < 26; j++)
        {
            if (back[j] - before[j] != letters[j])
                return false;
        }
    }
    return true;
}