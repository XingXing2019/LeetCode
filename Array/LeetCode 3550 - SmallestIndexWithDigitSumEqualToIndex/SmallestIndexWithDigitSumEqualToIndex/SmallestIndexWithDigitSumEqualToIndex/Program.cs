int SmallestIndex(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        int copy = nums[i], sum = 0;
        while (copy != 0)
        {
            sum += copy % 10;
            copy /= 10;
        }
        if (sum == i)
            return i;
    }
    return -1;
}