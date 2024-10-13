int[] MinBitwiseArray(IList<int> nums)
{
    var res = new int[nums.Count];
    for (int i = 0; i < nums.Count; i++)
        res[i] = nums[i] % 2 == 0 ? -1 : GetNum(nums[i]);
    return res;
}

int GetNum(int num)
{
    for (int i = 1; i <= 1000; i++)
    {
        if ((i | (i + 1)) == num)
            return i;
    }
    return -1;
}