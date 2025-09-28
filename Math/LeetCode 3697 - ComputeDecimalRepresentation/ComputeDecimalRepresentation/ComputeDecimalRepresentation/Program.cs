int[] DecimalRepresentation(int n)
{
    var res = new List<int>();
    var pow = 1;
    while (n != 0)
    {
        var num = n % 10 * pow;
        if (num != 0)
            res.Add(num);
        n /= 10;
        pow *= 10;
    }
    return res.OrderByDescending(x => x).ToArray();
}