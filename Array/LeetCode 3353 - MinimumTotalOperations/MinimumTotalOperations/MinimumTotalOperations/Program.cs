int[] nums = { -6, -6, -6, -1 };
Console.WriteLine(MinOperations(nums));
int MinOperations(int[] nums)
{
    int change = 0, res = 0;
    for (int i = nums.Length - 2; i >= 0; i--)
    {
        if (nums[i] + change != nums[i + 1])
        {
            change = nums[i + 1] - nums[i];
            res++;
        }
        nums[i] += change;
    }
    return res;
}