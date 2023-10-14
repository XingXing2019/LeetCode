IList<string> GetWordsInLongestSubsequence(int n, string[] words, int[] groups)
{
    var dp = new List<string>[n];
    int maxLen = -1, maxIndex = -1;
    for (int i = 0; i < words.Length; i++)
    {
        int max = -1, index = -1;
        for (int j = 0; j < i; j++)
        {
            if (groups[i] == groups[j] || !IsHammingDistanceOne(words[i], words[j]))
                continue;
            if (dp[j].Count + 1 > max)
            {
                max = dp[j].Count + 1;
                index = j;
            }
        }
        dp[i] = index == -1 ? new List<string> { words[i] } : new List<string>(dp[index]) { words[i] };
        if (dp[i].Count > maxLen)
        {
            maxLen = dp[i].Count;
            maxIndex = i;
        }
    }
    return dp[maxIndex];
}

bool IsHammingDistanceOne(string word1, string word2)
{
    if (word1.Length != word2.Length) 
        return false;
    var count = 0;
    for (int i = 0; i < word1.Length; i++)
    {
        if (word1[i] == word2[i]) continue;
        count++;
    }
    return count == 1;
}