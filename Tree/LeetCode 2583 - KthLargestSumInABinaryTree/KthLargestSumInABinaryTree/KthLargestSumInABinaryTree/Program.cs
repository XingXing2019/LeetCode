long KthLargestLevelSum(TreeNode root, int k)
{
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    var minHeap = new PriorityQueue<long, long>();
    while(queue.Count != 0)
    {
        var count = queue.Count;
        long sum = 0;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            sum += cur.val;
            if (cur.left != null) queue.Enqueue(cur.left);
            if (cur.right != null) queue.Enqueue(cur.right);
        }
        minHeap.Enqueue(sum, sum);
        if (minHeap.Count > k)
            minHeap.Dequeue();
    }
    return minHeap.Count < k ? -1 : minHeap.Dequeue();
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}