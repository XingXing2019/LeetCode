int[] ConcatWithReverse(int[] nums)
{
    var res = new int[nums.Length * 2];
    for (int i = 0; i < res.Length; i++)
    {
        var index = i < nums.Length ? i : nums.Length - i % nums.Length - 1;
        res[i] = nums[index];
    }
    return res;
}