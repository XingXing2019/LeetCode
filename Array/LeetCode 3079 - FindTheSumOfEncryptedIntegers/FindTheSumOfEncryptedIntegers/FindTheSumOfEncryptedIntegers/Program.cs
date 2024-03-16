int SumOfEncryptedInt(int[] nums)
{
    return nums.Sum(EncryptedInt);
}

int EncryptedInt(int num)
{
    int max = 0, count = 0, res = 0;
    while (num != 0)
    {
        max = Math.Max(max, num % 10);
        num /= 10;
        count++;
    }
    for (int i = 0; i < count; i++)
        res = res * 10 + max;
    return res;
}