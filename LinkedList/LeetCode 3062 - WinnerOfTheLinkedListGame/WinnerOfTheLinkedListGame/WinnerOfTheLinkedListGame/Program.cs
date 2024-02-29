string GameResult(ListNode head)
{
    var score = 0;
    while (head != null && head.next != null)
    {
        int even = head.val, odd = head.next.val;
        score += even == odd ? 0 : even > odd ? 1 : -1;
        head = head.next.next;
    }
    return score == 0 ? "Tie" : score > 0 ? "Even" : "Odd";
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