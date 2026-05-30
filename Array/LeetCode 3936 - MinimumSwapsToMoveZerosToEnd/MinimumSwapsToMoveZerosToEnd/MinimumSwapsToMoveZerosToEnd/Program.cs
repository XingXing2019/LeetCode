int[] nums = { 0, 1, 0, 3, 12 };
Console.WriteLine(MinimumSwaps(nums));

int MinimumSwaps(int[] nums)
{
    var res = 0;
    var sort = nums.OrderByDescending(x => x).ToArray();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0 && sort[i] == 0 || nums[i] != 0 && sort[i] != 0) continue;
        res++;
    }
    return res / 2;
}