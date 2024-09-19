int[] ToArray(Node node)
{
    var pre = new List<int>();
    var post = new List<int> { node.val };
    var prePoint = node.prev;
    var postPoint = node.next;
    while (prePoint != null)
    {
        pre.Add(prePoint.val);
        prePoint = prePoint.prev;
    }
    while (postPoint != null)
    {
        post.Add(postPoint.val);
        postPoint = postPoint.next;
    }
    pre.Reverse();
    return pre.Concat(post).ToArray();
}

class Node
{
    public int val;
    public Node prev;
    public Node next;
}