int MinArrayLength(int[] nums, int k)
{
    var stack = new Stack<long>();
    foreach (var num in nums)
    {
        long temp = num;
        while (stack.Count != 0 && stack.Peek() * temp <= k)
            temp *= stack.Pop();
        stack.Push(temp);
    }
    return stack.Count;
}