bool PartitionArray(int[] nums, int k)
{
    if (nums.Length % k != 0) return false;
    var num = nums.Length / k;
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    foreach (var f in freq.Values)
    {
        if (f <= num) continue;
        return false;
    }
    return true;
}