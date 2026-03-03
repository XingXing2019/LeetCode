var n = 3;
Console.WriteLine(MinCost(n));

int MinCost(int n)
{
    var res = 0;
    var ones = new int[n];
    Array.Fill(ones, 1);
    while (ones.Length != 1)
    {
        var temp = new List<int>();
        for (int i = 0; i < ones.Length; i += 2)
        {
            if (i == ones.Length - 1)
            {
                temp.Add(ones[i]);
            }
            else
            {
                temp.Add(ones[i] + ones[i + 1]);
                res += ones[i] * ones[i + 1];
            }
        }
        ones = temp.ToArray();
    }
    return res;
}