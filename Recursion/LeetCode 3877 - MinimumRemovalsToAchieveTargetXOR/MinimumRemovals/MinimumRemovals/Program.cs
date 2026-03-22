int[] nums = { 2, 4 };
var target = 1;
Console.WriteLine(MinRemovals(nums, target));

int MinRemovals(int[] nums, int target)
{
    var max = DFS(nums, 0, 0, target);
    return max < 0 ? -1 : nums.Length - max;
}

int DFS(int[] nums, int index, int xOr, int target)
{
    if (index >= nums.Length)
        return xOr == target ? 0 : int.MinValue;
    var take = DFS(nums, index + 1, xOr ^ nums[index], target) + 1;
    var skip = DFS(nums, index + 1, xOr, target);
    return Math.Max(take, skip);
}