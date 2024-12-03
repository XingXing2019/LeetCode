int[] SumPrefixScores(string[] words)
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
            point.count++;
        }
    }
    var res = new int[words.Length];
    for (var i = 0; i < words.Length; i++)
    {
        var point = root;
        foreach (var l in words[i])
        {
            point = point.children[l - 'a'];
            res[i] += point.count;
        }
    }
    return res;
}

class TrieNode
{
    public TrieNode[] children;
    public int count;

    public TrieNode()
    {
        children = new TrieNode[26];
    }
}