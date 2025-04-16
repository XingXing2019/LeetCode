int LargestInteger(int[] nums, int k)
{
    var res = -1;
    var set = new HashSet<int>(nums);
    foreach (var num in set)
    {
        var count = CountAppears(nums, num, k);
        if (count == 1 && num > res)
            res = num;
    }
    return res;
}

int CountAppears(int[] nums, int num, int k)
{
    int freq = 0, res = 0;
    for (int i = 0; i < k; i++)
    {
        if (nums[i] != num) continue;
        freq++;
    }
    for (int i = k; i < nums.Length; i++)
    {
        if (freq != 0) res++;
        if (nums[i] == num) freq++;
        if (nums[i - k] == num) freq--;
    }
    return freq == 0 ? res : res + 1;
}