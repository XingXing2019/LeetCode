int[] nums = { 7, 3, 7 };
int[] target = { 5, 5, 9 };
Console.WriteLine(MinOperations(nums, target));
int MinOperations(int[] nums, int[] target)
{
    var diff = new Dictionary<int, List<int>>();
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target[i]) continue;
        if (!diff.ContainsKey(nums[i]))
            diff[nums[i]] = new List<int>();
        diff[nums[i]].Add(i);
    }
    foreach (var indexes in diff.Values)
    {
        foreach (var index in indexes)
        {
            if (nums[index] == target[index]) continue;
            var p = index;
            while (p < nums.Length && nums[p] == nums[index])
            {
                nums[p] = target[p++];
            }
        }
        res++;
    }
    return res;
}