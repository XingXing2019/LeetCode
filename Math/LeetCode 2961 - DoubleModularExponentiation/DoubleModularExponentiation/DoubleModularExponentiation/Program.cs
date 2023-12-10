IList<int> GetGoodIndices(int[][] variables, int target)
{
    var res = new List<int>();
    for (int i = 0; i < variables.Length; i++)
    {
        int a = variables[i][0], b = variables[i][1], c = variables[i][2], m = variables[i][3];
        var pow1 = Pow(a, b, 10);
        var pow2 = Pow(pow1, c, m);
        if (pow2 == target)
            res.Add(i);
    }
    return res;
}

int Pow(int num1, int num2, int mod)
{
    if (num2 == 0)
        return 1;
    var pow = Pow(num1, num2 / 2, mod) % mod;
    return num2 % 2 == 0 ? pow * pow % mod : pow * pow * num1 % mod;
}