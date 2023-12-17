int[][] DivideArray(int[] nums, int k)
{
    var res = new List<int[]>();
    Array.Sort(nums);
    for (int i = 0; i <= nums.Length - 3; i += 3)
    {
        if (nums[i + 2] - nums[i] > k)
            return Array.Empty<int[]>();
        res.Add(new[] { nums[i], nums[i + 1], nums[i + 2] });
    }
    return res.ToArray();
}