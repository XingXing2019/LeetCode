var s = "kooo";
Console.WriteLine(LongestBalanced(s));

int LongestBalanced(string s)
{
    var res = 0;
    var prefix = new int[s.Length][];
    for (int i = 0; i < s.Length; i++)
    {
        prefix[i] = new int[26];
        if (i != 0)
            Array.Copy(prefix[i - 1], prefix[i], 26);
        prefix[i][s[i] - 'a']++;
    }
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i; j < s.Length; j++)
        {
            if (!IsValid(prefix, i, j)) continue;
            res = Math.Max(res, j - i + 1);
        }
    }
    return res;
}

bool IsValid(int[][] prefix, int li, int hi)
{
    var left = li == 0 ? new int[26] : prefix[li - 1];
    var right = prefix[hi];
    var set = new HashSet<int>();
    for (int i = 0; i < 26; i++)
    {
        if (left[i] == right[i]) continue;
        set.Add(right[i] - left[i]);
    }
    return set.Count == 1;
}