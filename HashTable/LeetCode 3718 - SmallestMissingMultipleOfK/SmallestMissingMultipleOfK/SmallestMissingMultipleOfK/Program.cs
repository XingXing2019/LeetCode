int MissingMultiple(int[] nums, int k)
{
    var set = new HashSet<int>(nums);
    for (int i = 1; i <= k * 200; i++)
    {
        if (!set.Contains(i * k))
            return i * k;
    }
    return -1;
}