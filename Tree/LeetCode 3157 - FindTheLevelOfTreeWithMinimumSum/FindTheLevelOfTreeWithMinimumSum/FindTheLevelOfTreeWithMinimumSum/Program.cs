int MinimumLevel(TreeNode root)
{
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int res = 1, level = 1;
    long min = root.val;
    while (queue.Count != 0)
    {
        var count = queue.Count;
        var sum = 0L;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            sum += cur.val;
            if (cur.left != null) queue.Enqueue(cur.left);
            if (cur.right != null) queue.Enqueue(cur.right);
        }
        if (sum < min)
        {
            min = sum;
            res = level;
        }
        level++;
    }
    return res;
}


class TreeNode
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