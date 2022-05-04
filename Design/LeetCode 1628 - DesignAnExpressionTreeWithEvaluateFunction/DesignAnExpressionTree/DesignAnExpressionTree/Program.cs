public abstract class Node
{
    public abstract int evaluate();
};

public class TreeNode : Node
{
    private readonly List<string> _postfix;

    public TreeNode(string[] postfix)
    {
        _postfix = new List<string>();
        foreach (var item in postfix)
            _postfix.Add(item);
    }

    public override int evaluate()
    {
        return DFS(_postfix);
    }

    private int DFS(List<string> postfix)
    {
        if (postfix.Count == 3)
        {
            int num1 = int.Parse(postfix[0]);
            int num2 = int.Parse(postfix[1]);
            if (postfix[^1] == "+")
                return num1 + num2;
            if (postfix[^1] == "-")
                return num1 - num2;
            if (postfix[^1] == "*")
                return num1 * num2;
            if (postfix[^1] == "/")
                return num1 / num2;
        }
        var index = 0;
        var front = new List<string>();
        while (index < postfix.Count && int.TryParse(postfix[index], out var num)) 
            front.Add(postfix[index++]);
        if (postfix[index] == "+")
            front[^2] = (int.Parse(front[^2]) + int.Parse(front[^1])).ToString();
        if (postfix[index] == "-")
            front[^2] = (int.Parse(front[^2]) - int.Parse(front[^1])).ToString();
        if (postfix[index] == "*")
            front[^2] = (int.Parse(front[^2]) * int.Parse(front[^1])).ToString();
        if (postfix[index] == "/")
            front[^2] = (int.Parse(front[^2]) / int.Parse(front[^1])).ToString();
        front.RemoveAt(front.Count - 1);
        index++;
        while (index < postfix.Count)
            front.Add(postfix[index++]);
        return DFS(front);
    }
}

public class TreeBuilder
{
    public Node buildTree(string[] postfix)
    {
        return new TreeNode(postfix);
    }
}