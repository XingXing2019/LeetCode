var nums = new List<int> { 1, 3, 1, 5 };
Console.WriteLine(FindMaximumScore(nums));

long FindMaximumScore(IList<int> nums)
{
    var nextGreater = new int[nums.Count];
    Array.Fill(nextGreater, -1);
    var stack = new Stack<int>();
    for (int i = 0; i < nums.Count; i++)
    {
        while (stack.Count != 0 && nums[i] > nums[stack.Peek()])
            nextGreater[stack.Pop()] = i;
        stack.Push(i);
    }
    var index = 0;
    long res = 0;
    while (nextGreater[index] != -1)
    {
        res += (long)nums[index] * (nextGreater[index] - index);
        index = nextGreater[index];
    }
    return res + (long)nums[index] * (nums.Count - 1 - index);
}