var nums = new List<int> { 5 };
Console.WriteLine(MinBitwiseArray(nums));

int[] MinBitwiseArray(IList<int> nums)
{
    var res = new int[nums.Count];
    for (int i = 0; i < nums.Count; i++)
        res[i] = nums[i] % 2 == 0 ? -1 : GetRes(nums[i]);
    return res;
}

int GetRes(int num)
{
    var digits = new List<int>();
    var copy = num;
    while (num != 0)
    {
        digits.Insert(0, num % 2);
        num /= 2;
    }
    for (int i = 0; i < digits.Count; i++)
    {
        if (digits[i] == 0) continue;
        num = GetNum(digits, i);
        if ((num | (num) + 1) == copy)
            return num;
    }
    return -1;
}

int GetNum(List<int> digits, int index)
{
    int num = 0, pow = 1;
    for (int i = digits.Count - 1; i >= 0; i--)
    {
        if (digits[i] != 0 && i != index)
            num += pow;
        pow *= 2;
    }
    return num;
}