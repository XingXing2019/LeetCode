int MinimumPairRemoval(int[] nums)
{
    var res = 0;
    while (!IsSorted(nums))
    {
        int min = int.MaxValue, index = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var sum = nums[i] + nums[i + 1];
            if (sum < min)
            {
                min = sum;
                index = i;
            }
        }
        var temp = new int[nums.Length - 1];
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == index)
                temp[i] = min;
            else if (i != index + 1)
            {
                if (i < index)
                    temp[i] = nums[i];
                else
                    temp[i - 1] = nums[i];
            }
        }
        nums = temp;
        res++;
    }

    return res;
}

bool IsSorted(int[] nums)
{
    for (int i = 0; i < nums.Length - 1; i++)
    {
        if (nums[i] <= nums[i + 1]) continue;
        return false;
    }
    return true;
}