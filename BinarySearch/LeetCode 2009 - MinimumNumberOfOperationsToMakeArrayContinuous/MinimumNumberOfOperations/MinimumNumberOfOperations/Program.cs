int[] nums = { 4, 2, 5, 3 };
Console.WriteLine(MinOperations(nums));

int MinOperations(int[] nums)
{
    var sorted = new HashSet<int>(nums).OrderBy(x => x).ToArray();
    var res = int.MaxValue;
    for (int i = 0; i < sorted.Length; i++)
    {
        var index = Array.BinarySearch(sorted, sorted[i] + nums.Length - 1);
        if (index < 0) index = ~index;
        var len = index < sorted.Length && sorted[index] == sorted[i] + nums.Length - 1 ? index - i + 1 : index - i;
        res = Math.Min(res, nums.Length - len);
    }
    return res;
}