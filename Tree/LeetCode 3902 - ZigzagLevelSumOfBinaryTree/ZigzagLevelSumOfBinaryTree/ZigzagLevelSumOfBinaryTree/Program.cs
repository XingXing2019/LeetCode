using System.Collections;

IList<long> ZigzagLevelSum(TreeNode root)
{
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    var level = 1;
    var res = new List<long>();
    while (queue.Count != 0)
    {
        var count = queue.Count;
        var temp = new List<TreeNode>();
        var sum = 0L;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            temp.Add(cur);
            if (cur.left != null) queue.Enqueue(cur.left);
            if (cur.right != null) queue.Enqueue(cur.right);
        }
        if (level % 2 != 0)
        {
            for (int i = 0; i < temp.Count && temp[i].left != null; i++)
            {
                sum += temp[i].val;
            }
        }
        else
        {
            for (int i = temp.Count - 1; i >= 0 && temp[i].right != null; i--)
            {
                sum += temp[i].val;
            }
        }
        res.Add(sum);
        level++;
    }
    return res;
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