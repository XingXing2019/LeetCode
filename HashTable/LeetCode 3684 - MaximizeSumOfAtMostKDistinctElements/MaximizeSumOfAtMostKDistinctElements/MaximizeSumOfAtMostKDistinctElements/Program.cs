int[] MaxKDistinct(int[] nums, int k)
{
    var set = new HashSet<int>(nums);
    return set.OrderByDescending(x => x).Take(Math.Min(set.Count, k)).ToArray();
}