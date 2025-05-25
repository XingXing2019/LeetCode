var word = "abca";
Console.WriteLine(MaxSubstrings(word));

int MaxSubstrings(string word)
{
    var res = 0;
    var dp = new int[word.Length];
    var dict = new Dictionary<char, List<int>>();
    var record = new Dictionary<char, int[]>();
    for (int i = 0; i < word.Length; i++)
    {
        if (!dict.ContainsKey(word[i]))
        {
            dict[word[i]] = new List<int>();
            record[word[i]] = new[] { 0, -1 };
        }
        dict[word[i]].Add(i);
    }
    for (int i = 3; i < dp.Length; i++)
    {
        var pos = dict[word[i]];
        int max = record[word[i]][1], start = record[word[i]][0];
        for (int j = start; j < pos.Count; j++)
        {
            if (i - pos[j] + 1 < 4) break;
            var count = pos[j] - 1 >= 0 ? dp[pos[j] - 1] : 0;
            if (count >= max)
            {
                max = count;
                record[word[i]] = new[] { j, max };
            }
        }
        dp[i] = max == -1 ? dp[i - 1] : Math.Max(dp[i - 1], max + 1);
        res = Math.Max(res, dp[i]);
    }
    return res;
}