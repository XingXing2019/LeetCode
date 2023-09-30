int MinOperations(IList<int> nums, int k)
{
    var collection = new HashSet<int>();
    for (int i = nums.Count - 1; i >= 0; i--)
    {
        if (nums[i] > k) continue;
        collection.Add(nums[i]);
        if (collection.Count == k)
            return nums.Count - i;
    }
    return -1;
}