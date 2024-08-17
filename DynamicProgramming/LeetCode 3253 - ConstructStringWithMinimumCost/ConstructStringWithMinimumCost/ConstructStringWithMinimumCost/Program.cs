var target = "abcdef";
string[] words = { "abdef", "abc", "d", "def", "ef" };
int[] costs = { 100, 1, 1, 10, 5 };
Console.WriteLine(MinimumCost(target, words, costs));

int MinimumCost(string target, string[] words, int[] costs)
{
    var dict = new Dictionary<string, int>();
    for (int i = 0; i < words.Length; i++)
    {
        if (!dict.ContainsKey(words[i]))
            dict[words[i]] = int.MaxValue;
        dict[words[i]] = Math.Min(dict[words[i]], costs[i]);
    }
    var dp = new int[target.Length + 1];
    Array.Fill(dp, int.MaxValue);
    dp[0] = 0;
    for (int i = 1; i < dp.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (dp[j] == int.MaxValue) continue;
            var word = target.Substring(j, i - j);
            if (dict.ContainsKey(word))
                dp[i] = Math.Min(dp[i], dp[j] + dict[word]);
        }
    }
    return dp[^1] == int.MaxValue ? -1 : dp[^1];
}