int SmallestAbsent(int[] nums)
{
    var avg = (double)nums.Sum() / nums.Length;
    var set = new HashSet<int>(nums);
    for (int i = 1; i < 200; i++)
    {
        if (set.Contains(i) || i <= avg) continue;
        return i;
    }
    return -1;
}