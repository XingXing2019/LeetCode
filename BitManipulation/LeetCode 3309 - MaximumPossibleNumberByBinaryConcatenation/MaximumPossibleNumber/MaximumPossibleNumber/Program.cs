int[] nums = { 1, 2, 3 };
Console.WriteLine(MaxGoodNumber(nums));

int MaxGoodNumber(int[] nums)
{
    int a = nums[0], b = nums[1], c = nums[2];
    var res = GetNum(a, b, c);
    res = Math.Max(res, GetNum(a, c, b));
    res = Math.Max(res, GetNum(b, a, c));
    res = Math.Max(res, GetNum(b, c, a));
    res = Math.Max(res, GetNum(c, a, b));
    res = Math.Max(res, GetNum(c, b, a));
    return res;
}

int GetNum(int a, int b, int c)
{
    int res = 0, pow = 1;
    var num = "";
    while (c != 0)
    {
        num = c % 2 + num;
        c /= 2;
    }
    while (b != 0)
    {
        num = b % 2 + num;
        b /= 2;
    }
    while (a != 0)
    {
        num = a % 2 + num;
        a /= 2;
    }
    for (int i = num.Length - 1; i >= 0; i--)
    {
        res += (num[i] - '0') * pow;
        pow *= 2;
    }
    return res;
}