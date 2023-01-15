int DifferenceOfSum(int[] nums)
{
    int elementSum = 0, digitSum = 0;
    for (var i = 0; i < nums.Length; i++)
    {
        elementSum += nums[i];
        while (nums[i] != 0)
        {
            digitSum += nums[i] % 10;
            nums[i] /= 10;
        }
    }
    return Math.Abs(elementSum - digitSum);
}