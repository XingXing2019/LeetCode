int[] nums = { 4 };
Console.WriteLine(MinOperations(nums));

int[] MinOperations(int[] nums)
{
    var res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = 0; j < nums[i]; j++)
        {
            if (IsPalindrome(nums[i] + j) || IsPalindrome(nums[i] - j))
            {
                res[i] = j;
                break;
            }
        }
    }
    return res;
}

bool IsPalindrome(int num)
{
    var digits = new List<int>();
    while (num != 0)
    {
        digits.Add(num % 2);
        num /= 2;
    }
    int li = 0, hi = digits.Count - 1;
    while (li < hi)
    {
        if (digits[li++] == digits[hi--]) continue;
        return false;
    }
    return true;
}