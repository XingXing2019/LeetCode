IList<int> FindValidElements(int[] nums)
{
    int left = int.MinValue, right = int.MinValue;
    var leftMax = new int[nums.Length];
    var rightMax = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        leftMax[i] = left;
        left = Math.Max(left, nums[i]);
        rightMax[^(i + 1)] = right;
        right = Math.Max(right, nums[^(i + 1)]);
    }
    var res = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] <= leftMax[i] && nums[i] <= rightMax[i]) continue;
        res.Add(nums[i]);
    }
    return res;
}