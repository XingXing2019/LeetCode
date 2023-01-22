var n = 521;
Console.WriteLine(AlternateDigitSum(n));

int AlternateDigitSum(int n)
{
    var res = 0;
    var num = n.ToString();
    for (int i = 0; i < num.Length; i++)
        res += i % 2 == 0 ? num[i] - '0' : -(num[i] - '0');
    return res;
}