int[] OrArray(int[] nums)
{
    var res = new int[nums.Length - 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = nums[i] | nums[i + 1];
    return res;
}