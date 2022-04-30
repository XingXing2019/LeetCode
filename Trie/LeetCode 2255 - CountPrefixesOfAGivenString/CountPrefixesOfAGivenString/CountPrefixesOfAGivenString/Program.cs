

int CountPrefixes(string[] words, string s)
{
    var root = new TrieNode();
    var point = root;
    var res = 0;
    foreach (var l in s)
    {
        point.children[l - 'a'] = new TrieNode();
        point = point.children[l - 'a'];
    }
    foreach (var word in words)
    {
        point = root;
        var isPrefix = true;
        foreach (var l in word)
        {
            if (point.children[l - 'a'] == null)
            {
                isPrefix = false;
                break;
            }
            point = point.children[l - 'a'];
        }
        if (isPrefix) res++;
    }
    return res;
}

class TrieNode
{
    public TrieNode[] children;

    public TrieNode()
    {
        children = new TrieNode[26];
    }
}