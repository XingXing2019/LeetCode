int MaximumPossibleSize(int[] nums)
{
    var stack = new Stack<int>();
    foreach (var num in nums)
    {
        if (stack.Count != 0 && num < stack.Peek()) continue;
        stack.Push(num);
    }
    return stack.Count;
}