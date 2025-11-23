int TotalWaviness(int num1, int num2)
{
    var res = 0;
    for (int i = num1; i <= num2; i++)
        res += Count(i.ToString());
    return res;
}

int Count(string num)
{
    var res = 0;
    for (int i = 1; i < num.Length - 1; i++)
    {
        if (num[i] < num[i - 1] && num[i] < num[i + 1] || num[i] > num[i - 1] && num[i] > num[i + 1])
            res++;
    }
    return res;
}