int LongestCommonPrefix(int[] arr1, int[] arr2)
{
    var root = new TrieNode();
    foreach (var num in arr1)
    {
        var point = root;
        foreach (var d in num.ToString())
        {
            if (point.children[d - '0'] == null)
                point.children[d - '0'] = new TrieNode();
            point = point.children[d - '0'];
        }
    }

    var res = 0;
    foreach (var num in arr2)
    {
        var point = root;
        var len = 0;
        foreach (var d in num.ToString())
        {
            if (point.children[d - '0'] == null)
                break;
            len++;
            point = point.children[d - '0'];
        }
        res = Math.Max(res, len);
    }
    return res;
}

class TrieNode
{
    public int val;
    public TrieNode[] children;

    public TrieNode()
    {
        children = new TrieNode[10];
    }
}