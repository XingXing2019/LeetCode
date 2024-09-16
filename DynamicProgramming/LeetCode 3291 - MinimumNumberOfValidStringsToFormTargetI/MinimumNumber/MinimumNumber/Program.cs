string[] words = { "abc", "aaaaa", "bcdef" };
var target = "aabcdabc";
Console.WriteLine(MinValidStrings(words, target));

int MinValidStrings(string[] words, string target)
{
    var root = new TrieNode();
    foreach (var word in words)
    {
        var point = root;
        foreach (var l in word)
        {
            if (point.children[l - 'a'] == null)
                point.children[l - 'a'] = new TrieNode();
            point = point.children[l - 'a'];
        }
    }
    var dp = new int[target.Length];
    for (int i = 0; i < dp.Length; i++)
    {
        var min = int.MaxValue;
        for (int j = 0; j <= i; j++)
        {
            if (IsMatch(target, j, i, root))
                min = Math.Min(min, j == 0 ? 0 : dp[j - 1]);
        }
        if (min == int.MaxValue)
            return -1;
        dp[i] = min + 1;
    }
    return dp[^1];
}

bool IsMatch(string target, int li, int hi, TrieNode root)
{
    var point = root;
    for (int i = li; i <= hi; i++)
    {
        if (point.children[target[i] - 'a'] == null)
            return false;
        point = point.children[target[i] - 'a'];
    }
    return true;
}

class TrieNode
{
    public TrieNode[] children;

    public TrieNode()
    {
        children = new TrieNode[26];
    }
}