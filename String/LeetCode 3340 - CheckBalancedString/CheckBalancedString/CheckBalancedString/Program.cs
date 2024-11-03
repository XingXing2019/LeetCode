bool IsBalanced(string num)
{
    var res = 0;
    for (int i = 0; i < num.Length; i++)
    {
        var digit = num[i] - '0';
        res += i % 2 == 0 ? digit : -digit;
    }
    return res == 0;
}