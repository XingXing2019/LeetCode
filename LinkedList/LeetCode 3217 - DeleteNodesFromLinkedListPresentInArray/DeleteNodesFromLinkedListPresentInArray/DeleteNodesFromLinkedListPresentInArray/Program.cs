ListNode ModifiedList(int[] nums, ListNode head)
{
    var set = new HashSet<int>(nums);
    var dummy = new ListNode(0, head);
    var point = dummy;
    while (head != null)
    {
        if (!set.Contains(head.val))
        {
            point.next = head;
            point = point.next;
        }
        head = head.next;
    }
    point.next = null;
    return dummy.next;
}


class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}