int[] nums = { 6, 7, 7, 7, 8, 10, 10 };
Console.WriteLine(MaxDistinctElements(nums, 1));

int MaxDistinctElements(int[] nums, int k)
{
    Array.Sort(nums);
    int diff = -k;
    var set = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    { 
        if (i != 0 && nums[i] == nums[i - 1])
            diff++;
        if (i != 0 && nums[i] - nums[i - 1] > k + 1)
            diff = -k;
        if (diff <= k)
        {
            if (set.Count != 0 && nums[i] + diff - set[^1] > 1 && diff - 1 >= -k)
                diff--;
            set.Add(nums[i] + diff);
        }            
        else
            set.Add(nums[i] + k);
    }
    return new HashSet<int>(set).Count;
}