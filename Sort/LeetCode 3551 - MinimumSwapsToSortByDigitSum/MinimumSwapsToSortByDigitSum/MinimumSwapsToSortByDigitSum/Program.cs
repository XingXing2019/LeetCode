int[] nums = { 625468152, 191921893, 821181574 };
Console.WriteLine(MinSwaps(nums));
int MinSwaps(int[] nums)
{
    var copy = new int[nums.Length];
    Array.Copy(nums, copy, nums.Length);
    Array.Sort(copy, (a, b) =>
    {
        int sumA = GetSum(a), sumB = GetSum(b);
        return sumA == sumB ? a - b : sumA - sumB;
    });
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
        dict[nums[i]] = i;
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == copy[i]) continue;
        int num = nums[i], index = dict[copy[i]];
        (nums[i], nums[dict[copy[i]]]) = (nums[dict[copy[i]]], nums[i]);
        dict[num] = index;
        res++;
    }
    return res;
}

int GetSum(int num)
{
    var res = 0;
    while (num != 0)
    {
        res += num % 10;
        num /= 10;
    }
    return res;
}