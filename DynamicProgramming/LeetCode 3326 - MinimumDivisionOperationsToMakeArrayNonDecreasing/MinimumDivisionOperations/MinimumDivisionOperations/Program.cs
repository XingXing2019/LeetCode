int[] nums = { 125, 7 };
Console.WriteLine(MinOperations(nums));

int MinOperations(int[] nums)
{
    var max = nums.Max();
    var gpd = GPD(max);
    var res = 0;
    for (int i = nums.Length - 2; i >= 0; i--)
    {
        if (nums[i] <= nums[i + 1]) continue;
        while (nums[i] > nums[i + 1] && nums[i] % gpd[nums[i]] == 0 && nums[i] != gpd[nums[i]])
        {
            nums[i] /= gpd[nums[i]];
            res++;
        }
        if (nums[i] > nums[i + 1])
            return -1;
    }
    return res;
}

int[] GPD(int num)
{
    var res = new int[num + 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = i;
    for (int i = 2; i < res.Length; i++)
    {
        for (int j = 2; i * j < res.Length; j++)
            res[i * j] = i;
    }
    return res;
}