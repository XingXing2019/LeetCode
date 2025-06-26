int[] OnceTwice(int[] nums)
{
    Array.Sort(nums);
    int count = 0, cur = nums[0];
    var res = new int[2];
    foreach (var num in nums)
    {
        if (num == cur)
            count++;
        else
        {
            if (count == 1)
                res[0] = cur;
            else if (count == 2)
                res[1] = cur;
            count = 1;
            cur = num;
        }
    }
    if (count == 1)
        res[0] = cur;
    else if (count == 2)
        res[1] = cur;
    return res;
}