var k = 11;
Console.WriteLine(MinOperations(k));

int MinOperations(int k)
{
    var res = int.MaxValue;
    for (int i = 0; i <= k; i++)
    {
        var ops = (i - 1) + (int)Math.Ceiling((double)k / (1 + i));
        res = Math.Min(res, ops);
    }
    return res;
}