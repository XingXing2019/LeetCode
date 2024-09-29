int MinElement(int[] nums)
{
    return nums.Select(x =>
    {
        var sum = 0;
        while (x != 0)
        {
            sum += x % 10;
            x /= 10;
        }
        return sum;
    }).Min();
}