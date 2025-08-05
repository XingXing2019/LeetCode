int[] weight = { 2, 5, 1, 4, 3 };
Console.WriteLine(MaxBalancedShipments(weight));

int MaxBalancedShipments(int[] weight)
{
    int res = 0, max = int.MinValue;
    foreach (var w in weight)
    {
        if (w < max)
        {
            res++;
            max = int.MinValue;
        }
        else
            max = Math.Max(max, w);
    }
    return res;
}