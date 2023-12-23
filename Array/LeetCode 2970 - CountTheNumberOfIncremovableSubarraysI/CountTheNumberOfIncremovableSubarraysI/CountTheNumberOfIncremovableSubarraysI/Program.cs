int[] nums = { 8, 7, 6, 6 };
Console.WriteLine(IncremovableSubarrayCount(nums));

int IncremovableSubarrayCount(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i; j < nums.Length; j++)
        {
            if (IsIncreasing(nums[..i].Concat(nums[(j + 1)..]).ToArray()))
                res++;
        }
    }
    return res;
}

bool IsIncreasing(int[] nums)
{
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] <= nums[i - 1])
            return false;
    }
    return true;
}