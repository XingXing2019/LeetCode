int KthLargestPerfectSubtree(TreeNode root, int k)
{
    var nodes = new List<int>();
    DFS(root, nodes);
    nodes.Sort((a, b) => b - a);
    return nodes.Count < k ? -1 : nodes[k - 1];
}

int[] DFS(TreeNode root, List<int> nodes)
{
    if (root == null)
        return new[] { 0, 0 };
    var left = DFS(root.left, nodes);
    var right = DFS(root.right, nodes);
    if (root.left == root.right || left[0] == 1 && right[0] == 1 && left[1] == right[1])
    {
        nodes.Add(left[1] * 2 + 1);
        return new[] { 1, left[1] * 2 + 1 };
    }
    return new[] { 0, 0 };
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