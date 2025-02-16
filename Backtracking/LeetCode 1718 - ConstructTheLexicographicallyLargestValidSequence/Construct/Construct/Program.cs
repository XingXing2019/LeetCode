var n = 5;
Console.WriteLine(ConstructDistancedSequence(n));

int[] ConstructDistancedSequence(int n)
{
    var nums = new int[2 * n - 1];
    DFS(0, n, new HashSet<int>(), nums);
    return nums;
}

bool DFS(int index, int n, HashSet<int> used, int[] nums)
{
    if (index == nums.Length)
        return true;
    if (nums[index] != 0)
        return DFS(index + 1, n, used, nums);
    for (int i = n; i >= 1; i--)
    {
        if (used.Contains(i)) continue;
        if (i != 1 && (i + index >= nums.Length || nums[i + index] != 0)) continue;
        used.Add(i);
        nums[index] = i;
        if (i != 1) nums[i + index] = i;
        if (DFS(index + 1, n, used, nums))
            return true;
        used.Remove(i);
        nums[index] = 0;
        if (i != 1) nums[i + index] = 0;
    }
    return false;
}