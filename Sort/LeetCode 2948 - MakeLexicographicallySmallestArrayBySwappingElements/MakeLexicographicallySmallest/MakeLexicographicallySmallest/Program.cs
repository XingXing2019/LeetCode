int[] nums = { 1, 7, 6, 18, 2, 1 };
var limit = 3;
Console.WriteLine(LexicographicallySmallestArray(nums, limit));

int[] LexicographicallySmallestArray(int[] nums, int limit)
{
    var indexes = new int[nums.Length];
    var res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        indexes[i] = i;
    indexes = indexes.OrderBy(x => nums[x]).ToArray();
    var groups = new List<List<int>>();
    var group = new List<int>();
    for (int i = 0; i < indexes.Length; i++)
    {
        var diff = i == 0 ? 0 : nums[indexes[i]] - nums[indexes[i - 1]];
        if (diff <= limit)
            group.Add(indexes[i]);
        else
        {
            groups.Add(new List<int>(group));
            group = new List<int> { indexes[i] };
        }
    }
    groups.Add(group);
    foreach (var g in groups)
    {
        var temp = g.OrderBy(x => x).ToArray();
        for (int i = 0; i < temp.Length; i++)
        {
            res[temp[i]] = nums[g[i]];
        }
    }
    return res;
}