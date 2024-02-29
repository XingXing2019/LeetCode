ListNode FrequenciesOfElements(ListNode head)
{
    var freq = new Dictionary<int, int>();
    while (head != null)
    {
        if (!freq.ContainsKey(head.val))
            freq[head.val] = 0;
        freq[head.val]++;
        head = head.next;
    }
    ListNode res = null;
    foreach (var val in freq.Values)
        res = new ListNode(val, res);
    return res;
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}