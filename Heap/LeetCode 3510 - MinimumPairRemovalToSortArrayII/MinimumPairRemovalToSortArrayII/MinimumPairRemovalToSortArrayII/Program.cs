int[] nums = { 1, 1, 3, 1 };
Console.WriteLine(MinimumPairRemoval(nums));

int MinimumPairRemoval(int[] nums)
{
    int res = 0, decreasing = 0;
    var heap = new PriorityQueue<ListNode, ListNode>();
    var dict = new Dictionary<int, ListNode>();
    var indexes = new HashSet<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        var pre = i == 0 ? null : dict[i - 1];
        var pairSum = i == nums.Length - 1 ? int.MaxValue : nums[i] + nums[i + 1];
        var cur = new ListNode(i, nums[i], pairSum, pre, null);
        if (pre != null)
            pre.PostNode = cur;
        if (i != 0 && nums[i] < nums[i - 1])
        {
            decreasing++;
            indexes.Add(i);
        }
        dict[i] = cur;
        heap.Enqueue(cur, cur);
    }
    while (decreasing != 0)
    {
        while (heap.Peek().IsRemoved)
            heap.Dequeue();
        var min = heap.Dequeue();
        var pairSum = min.PairSum;
        var pre = min.PreNode;
        var post = min.PostNode.PostNode;
        min.CurValue = pairSum;
        min.PairSum = post == null ? int.MaxValue : min.CurValue + post.CurValue;
        min.PostNode.IsRemoved = true;
        if (pre != null && indexes.Contains(min.Index))
        {
            if (min.CurValue >= pre.CurValue)
            {
                decreasing--;
                indexes.Remove(min.Index);
            }
        }
        min.PostNode = post;
        if (post != null)
            post.PreNode = min;
        if (pre != null)
            pre.PairSum = pre.CurValue + min.CurValue;
        res++;
    }
    return res;
}

class ListNode : IComparable<ListNode>
{
    public int Index { get; set; }
    public int CurValue { get; set; }
    public int PairSum { get; set; }
    public ListNode PreNode { get; set; }
    public ListNode PostNode { get; set; }
    public bool IsRemoved { get; set; }

    public ListNode(int index, int curValue, int pairSum, ListNode preNode, ListNode postNode)
    {
        Index = index;
        CurValue = curValue;
        PairSum = pairSum;
        PreNode = preNode;
        PostNode = postNode;
    }

    public int CompareTo(ListNode? other)
    {
        return this.PairSum == other.PairSum ? other.Index - this.Index : this.PairSum - other.PairSum;
    }
}