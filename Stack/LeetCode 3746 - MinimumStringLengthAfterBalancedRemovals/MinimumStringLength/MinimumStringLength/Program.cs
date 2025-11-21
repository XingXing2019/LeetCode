int MinLengthAfterRemovals(string s)
{
    var stack = new Stack<char>();
    foreach (var l in s)
    {
        if (stack.Count == 0 || stack.Peek() == l)
            stack.Push(l);
        else
            stack.Pop();
    }
    return stack.Count;
}