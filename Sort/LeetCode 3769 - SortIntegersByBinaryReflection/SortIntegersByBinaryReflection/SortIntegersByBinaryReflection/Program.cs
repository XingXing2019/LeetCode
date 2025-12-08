int[] SortByReflection(int[] nums)
{
    return nums.OrderBy(Reverse).ThenBy(x => x).ToArray();
}

int Reverse(int num)
{
    var res = 0;
    while (num != 0)
    {
        res = res * 2 + num % 2;
        num /= 2;
    }
    return res;
}