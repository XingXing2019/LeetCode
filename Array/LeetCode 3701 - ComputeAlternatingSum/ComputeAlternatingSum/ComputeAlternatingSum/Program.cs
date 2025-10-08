int AlternatingSum(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
        res += i % 2 == 0 ? nums[i] : -nums[i];
    return res;
}