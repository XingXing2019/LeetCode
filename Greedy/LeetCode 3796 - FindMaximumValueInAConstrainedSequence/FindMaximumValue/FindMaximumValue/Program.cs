int FindMaxVal(int n, int[][] restrictions, int[] diff)
{
    var nums = new int[n];
    Array.Fill(nums, int.MaxValue);
    nums[0] = 0;
    foreach (var restriction in restrictions)
        nums[restriction[0]] = restriction[1];
    for (int i = 1; i < nums.Length; i++)
        nums[i] = Math.Min(nums[i], nums[i - 1] + diff[i - 1]);
    for (int i = nums.Length - 2; i >= 0; i--)
        nums[i] = Math.Min(nums[i], nums[i + 1] + diff[i]);
    return nums.Max();
}