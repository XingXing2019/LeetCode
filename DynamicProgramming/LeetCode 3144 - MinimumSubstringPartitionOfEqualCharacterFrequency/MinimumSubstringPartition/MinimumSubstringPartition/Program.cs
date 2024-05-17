var s = "fabccddg";
Console.WriteLine(MinimumSubstringsInPartition(s));
int MinimumSubstringsInPartition(string s)
{
    var freq = new int[s.Length][];
    for (int i = 0; i < s.Length; i++)
    {
        freq[i] = new int[26];
        if (i != 0)
            Array.Copy(freq[i - 1], freq[i], 26);
        freq[i][s[i] - 'a']++;
    }
    var dp = new int[s.Length];
    dp[0] = 1;
    for (int i = 1; i < s.Length; i++)
    {
        var min = int.MaxValue;
        for (int j = 0; j <= i && min != 0; j++)
        {
            if (!IsBalance(freq, i, j)) continue;
            min = Math.Min(min, j == 0 ? 0 : dp[j - 1]);
        }
        dp[i] = min + 1;
    }
    return dp[^1];
}

bool IsBalance(int[][] freq, int i, int j)
{
    var freq1 = j == 0 ? new int[26] : freq[j - 1];
    var freq2 = freq[i];
    var diff = new HashSet<int>();
    for (int k = 0; k < 26; k++)
    {
        if (freq1[k] == freq2[k]) continue;
        diff.Add(freq2[k] - freq1[k]);
    } 
    return diff.Count == 1;
}