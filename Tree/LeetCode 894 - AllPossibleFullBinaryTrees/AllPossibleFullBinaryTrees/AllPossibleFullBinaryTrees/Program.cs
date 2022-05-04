IList<TreeNode> AllPossibleFBT(int n)
{
    if (n % 2 == 0) return new List<TreeNode>();
    if (n == 1) return new List<TreeNode> { new() };
    var res = new List<TreeNode>();
    for (int i = 1; i < n; i += 2)
    {
        foreach (var left in AllPossibleFBT(i))
        {
            foreach (var right in AllPossibleFBT(n - 1 - i))
            {
                res.Add(new TreeNode(0, left, right));
            }
        }
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