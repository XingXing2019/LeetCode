IList<int> FindMissingElements(int[] nums)
{
    Array.Sort(nums);
    var res = new List<int>();
    int count = nums[0], index = 0;
    while (index < nums.Length)
    {
        var num = nums[index];
        if (num != count)
            res.Add(count);
        else
            index++;
        count++;
    }
    return res;
}