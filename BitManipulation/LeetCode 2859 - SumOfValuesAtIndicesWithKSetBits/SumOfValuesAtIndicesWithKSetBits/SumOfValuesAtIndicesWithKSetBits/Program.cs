var nums = new List<int> { 5, 10, 1, 5, 2 };
var k = 1;
Console.WriteLine(SumIndicesWithKSetBits(nums, k));

int SumIndicesWithKSetBits(IList<int> nums, int k)
{
    return nums.Where((x, i) => IsKSetBits(i, k)).Select((x, i) => x).Sum();
}

bool IsKSetBits(int num, int k)
{
    while (num != 0)
    {
        if ((num & 1) == 1)
            k--;
        num >>= 1;
    }
    return k == 0;
}