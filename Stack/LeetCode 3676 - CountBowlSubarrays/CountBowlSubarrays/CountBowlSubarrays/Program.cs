long BowlSubarrays(int[] nums)
{
    var res = 0L;
    var stack = new Stack<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        while (stack.Count != 0 && nums[i] > nums[stack.Peek()])
        {
            stack.Pop();
            if (stack.Count != 0)
                res++;
        }
        stack.Push(i);
    }
    return res;
}