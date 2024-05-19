bool IsArraySpecial(int[] nums)
{
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] % 2 == nums[i - 1] % 2)
            return false;
    }
    return true;
}