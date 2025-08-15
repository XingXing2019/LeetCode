int[] nums = { 0, 1, 3, 2 };
Console.WriteLine(SortPermutation(nums));

int SortPermutation(int[] nums)
{
    int max = (1 << 30) - 1, res = max;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == i) continue;
        res &= nums[i];
    }
    return res == max ? 0 : res;
}