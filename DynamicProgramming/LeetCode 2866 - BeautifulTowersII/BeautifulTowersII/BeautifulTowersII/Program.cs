var maxHeights = new List<int> { 5, 3, 4, 1, 1 };
Console.WriteLine(MaximumSumOfHeights(maxHeights));

long MaximumSumOfHeights(IList<int> maxHeights)
{
    var left = GetLeft(maxHeights);
    var right = GetRight(maxHeights);
    long res = 0;
    for (int i = 0; i < maxHeights.Count; i++)
        res = Math.Max(res, left[i] + right[i]);
    return res;
}

long[] GetLeft(IList<int> maxHeights)
{
    var stack = new Stack<int>();
    var left = new long[maxHeights.Count];
    for (int i = 0; i < maxHeights.Count; i++)
    {
        while (stack.Count != 0 && maxHeights[stack.Peek()] >= maxHeights[i])
            stack.Pop();
        left[i] = stack.Count == 0 ? (long)maxHeights[i] * (i + 1) : (long)maxHeights[i] * (i - stack.Peek()) + left[stack.Peek()];
        stack.Push(i);
    }
    return left;
}

long[] GetRight(IList<int> maxHeights)
{
    var stack = new Stack<int>();
    var right = new long[maxHeights.Count];
    for (int i = maxHeights.Count - 1; i >= 0; i--)
    {
        while (stack.Count != 0 && maxHeights[stack.Peek()] >= maxHeights[i])
            stack.Pop();
        right[i] = stack.Count == 0 ? (long)maxHeights[i] * (maxHeights.Count - i - 1) : (long)maxHeights[i] * (stack.Peek() - i - 1) + right[stack.Peek()] + maxHeights[stack.Peek()];
        stack.Push(i);
    }
    return right;
}