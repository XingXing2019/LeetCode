IList<long> MergeAdjacent(int[] nums)
{
    var stack = new Stack<long>();
    foreach (var num in nums)
    {
        long cur = num;
        while (stack.Count != 0 && stack.Peek() == cur)
            cur += stack.Pop();
        stack.Push(cur);
    }
    return stack.Reverse().ToList();
}