int[] nums = { 8, 4, 2, 30, 15 };
Console.WriteLine(CanSortArray(nums));

bool CanSortArray(int[] nums)
{
    int min = nums[0], max = nums[0];
    var count = Count(nums[0]);
    var limits = new List<int[]>();
    foreach (var num in nums)
    {
        var tempCount = Count(num);
        if (tempCount != count)
        {
            limits.Add(new[] { min, max });
            count = tempCount;
            min = max = num;
        }
        min = Math.Min(min, num);
        max = Math.Max(max, num);
    }
    limits.Add(new[] { min, max });
    for (int i = 1; i < limits.Count; i++)
    {
        if (limits[i - 1][1] > limits[i][0])
            return false;
    }
    return true;
}

int Count(int num)
{
    var res = 0;
    while (num != 0)
    {
        res += num % 2;
        num /= 2;
    }
    return res;
}