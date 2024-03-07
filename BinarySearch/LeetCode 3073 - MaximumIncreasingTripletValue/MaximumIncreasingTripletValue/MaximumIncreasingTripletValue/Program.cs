int[] nums = { 7, 24, 7, 29 };
Console.WriteLine(MaximumTripletValue(nums));

int MaximumTripletValue(int[] nums)
{
    var rightMax = new int[nums.Length];
    var left = new SortedList<int, int> { { nums[0], nums[0] } };
    int max = 0, res = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        rightMax[i] = max;
        max = Math.Max(max, nums[i]);
    }
    for (int i = 1; i < nums.Length - 1; i++)
    {
        if (nums[i] < rightMax[i])
        {
            var leftMax = BinarySearch(left.Keys, nums[i] - 1);
            if (leftMax < nums[i])
            {
                res = Math.Max(res, leftMax - nums[i] + rightMax[i]);
            }
        }
        if (left.ContainsKey(nums[i])) continue;
        left.Add(nums[i], nums[i]);
    }
    return res;
}

int BinarySearch(IList<int> nums, int target)
{
    int li = 0, hi = nums.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (nums[mid] == target)
            return target;
        if (nums[mid] < target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi < 0 ? nums[li] : nums[hi];
}