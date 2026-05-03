int[] CountOppositeParity(int[] nums)
{
    int odd = 0, even = 0;
    var suffix = new int[nums.Length][];
    var res = new int[nums.Length];
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        suffix[i] = new[] { even, odd };
        res[i] = suffix[i][(nums[i] % 2) ^ 1];
        if (nums[i] % 2 == 0) even++;
        else odd++;
    }
    return res;
}