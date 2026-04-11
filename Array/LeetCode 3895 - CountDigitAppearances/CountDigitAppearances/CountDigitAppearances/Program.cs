int CountDigitOccurrences(int[] nums, int digit)
{
    return nums.Sum(x => Count(x, digit));
}

int Count(int num, int digit)
{
    var res = 0;
    while (num != 0)
    {
        if (num % 10 == digit) res++;
        num /= 10;
    }
    return res;
}