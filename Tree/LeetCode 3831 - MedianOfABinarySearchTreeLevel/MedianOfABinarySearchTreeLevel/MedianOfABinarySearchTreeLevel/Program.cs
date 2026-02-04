var a = new TreeNode(4);
var b = new TreeNode(5);
var c = new TreeNode(7);
a.right = b;
b.right = c;
Console.WriteLine(LevelMedian(a, 2));

int LevelMedian(TreeNode root, int level)
{
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    while (queue.Count != 0)
    {
        var count = queue.Count;
        var minHeap = new PriorityQueue<int, int>();
        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            minHeap.Enqueue(cur.val, cur.val);
            if (minHeap.Count > maxHeap.Count + 1)
            {
                var min = minHeap.Dequeue();
                maxHeap.Enqueue(min, -min);
            }
            if (cur.left != null) queue.Enqueue(cur.left);
            if (cur.right != null) queue.Enqueue(cur.right);
        }
        if (level == 0)
            return minHeap.Peek();
        level--;
    }
    return -1;
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