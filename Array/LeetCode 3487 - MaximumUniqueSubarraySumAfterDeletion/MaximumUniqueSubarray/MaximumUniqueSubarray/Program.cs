int MaxSum(int[] nums)
{
    var set = new HashSet<int>(nums.Where(x => x > 0));
    return set.Count == 0 ? nums.Max() : set.Sum();
}