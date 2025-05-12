int[] nums = { 7, 2, 0, 4, 2 };
Console.WriteLine(MinOperations(nums));

int MinOperations(int[] nums)
{
    var stack = new Stack<int>();
    int res = 0, last = -1;
    for (int i = 0; i < nums.Length; i++)
    {
        last = -1;
        while (stack.Count != 0 && nums[i] < nums[stack.Peek()])
        {
            var peek = stack.Pop();
            if (nums[peek] != last)
                res++;
            last = nums[peek];
        }
        stack.Push(i);
    }
    last = -1;
    while (stack.Count != 0 && nums[stack.Peek()] != 0)
    {
        var peek = stack.Pop();
        if (nums[peek] != last)
            res++;
        last = nums[peek];
    }
    return res;
}