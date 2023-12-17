int[] nums = { 1, 2, 3, 4, 5 };
Console.WriteLine(MinimumCost(nums));

long MinimumCost(int[] nums)
{
    Array.Sort(nums);
    var median = nums[nums.Length / 2];
    var palindromic1 = GetPalindromic(median, 1);
    var palindromic2 = GetPalindromic(median, -1);
    var sum1 = nums.Sum(x => Math.Abs((long)x - palindromic1));
    var sum2 = nums.Sum(x => Math.Abs((long)x - palindromic2));
    return Math.Min(sum1, sum2);
}

bool IsPalindromic(int num)
{
    var str = num.ToString();
    int li = 0, hi = str.Length - 1;
    while (li < hi)
    {
        if (str[li] != str[hi])
            return false;
        li++;
        hi--;
    }
    return true;
}

int GetPalindromic(int num, int diff)
{
    while (!IsPalindromic(num))
        num += diff;
    return num;
}