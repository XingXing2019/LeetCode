int[] nums = { 2, 7, 9, 6, 4, 6 };
Console.WriteLine(NumberGame(nums));

int[] NumberGame(int[] nums)
{
    Array.Sort(nums);
    var res = new int[nums.Length];
    int index = 0, p1 = 0, p2 = 1;
    while (p2 < nums.Length)
    {
        res[index++] = nums[p2];
        res[index++] = nums[p1];
        p1 += 2;
        p2 += 2;
    }
    return res;
}