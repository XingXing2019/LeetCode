using System.Linq;

string[] words = { "cat", "dog", "catdog" };
Console.WriteLine(FindAllConcatenatedWordsInADict(words));

IList<string> FindAllConcatenatedWordsInADict(string[] words)
{
    var set = new HashSet<string>(words);
    var res = new List<string>();
    foreach (var word in words)
    {
        var n = word.Length;
        var dp = new bool[n + 1];
        Array.Fill(dp, false);
        dp[0] = true;
        for (int i = 0; i < n; i++)
        {
            if (!dp[i]) continue;
            for (int j = i + 1; j <= n; j++)
            {
                if (j - i < n && set.Contains(word.Substring(i, j - i)))
                {
                    dp[j] = true;
                }
            }
            if (dp[n])
            {
                res.Add(word);
                break;
            }
        }
    }
    return res;
}