int[] maximumHeight = { 15, 10 };
Console.WriteLine(MaximumTotalSum(maximumHeight));

long MaximumTotalSum(int[] maximumHeight)
{
    Array.Sort(maximumHeight, (a, b) => b - a);
    long res = maximumHeight[0];
    var max = maximumHeight[0];
    for (var i = 1; i < maximumHeight.Length; i++)
    {
        var height = Math.Min(maximumHeight[i], max);
        if (height == max) height--;
        if (height == 0) return -1;
        res += height;
        max = height;
    }
    return res;
}