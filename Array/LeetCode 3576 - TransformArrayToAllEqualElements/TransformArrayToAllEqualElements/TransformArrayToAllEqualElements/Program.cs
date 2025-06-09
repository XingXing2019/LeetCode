int[] nums = { 1, -1, 1, -1, 1, -1, 1, -1, -1, -1 };
var k = 4;
Console.WriteLine(CanMakeEqual(nums, k));

bool CanMakeEqual(int[] nums, int k)
{
    return ChangeAll(nums, k, 1) || ChangeAll(nums, k, -1);
}

bool ChangeAll(int[] nums, int k, int target)
{
    var indexes = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target) continue;
        indexes.Add(i);
    }
    if (indexes.Count % 2 != 0) return false;
    var count = 0;
    for (int i = 0; i < indexes.Count; i+=2)
        count += indexes[i + 1] - indexes[i];
    return count <= k;
}
