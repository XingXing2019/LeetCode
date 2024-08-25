int[] ToArray(Node head)
{
    var res = new List<int>();
    while (head != null)
    {
        res.Add(head.val);
        head = head.next;
    }
    return res.ToArray();
}

public class Node
{
    public int val;
    public Node prev;
    public Node next;
}