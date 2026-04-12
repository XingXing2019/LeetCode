int[] nums = { 1, 0, 0, 2, 0, 1 };
Console.WriteLine(MinAbsoluteDifference(nums));

int MinAbsoluteDifference(int[] nums)
{
    var one = new List<int>();
    var two = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 1) one.Add(i);
        else if (nums[i] == 2) two.Add(i);
    }
    var res = int.MaxValue;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 1)
        {
            var index = ~two.BinarySearch(i);
            if (index == two.Count) continue;
            res = Math.Min(res, two[index] - i);
        }
        else if (nums[i] == 2)
        {
            var index = ~one.BinarySearch(i);
            if (index == one.Count) continue;
            res = Math.Min(res, one[index] - i);
        }
    }
    return res == int.MaxValue ? -1 : res;
}