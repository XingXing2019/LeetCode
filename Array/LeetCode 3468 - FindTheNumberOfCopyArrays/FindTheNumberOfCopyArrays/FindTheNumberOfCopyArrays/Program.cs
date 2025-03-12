int CountArrays(int[] original, int[][] bounds)
{
    int li = bounds[0][0], hi = bounds[0][1];
    for (int i = 1; i < original.Length; i++)
    {
        var diff = original[i] - original[i - 1];
        li += diff;
        hi += diff;
        if (hi < bounds[i][0] || li > bounds[i][1])
            return 0;
        li = Math.Max(li, bounds[i][0]);
        hi = Math.Min(hi, bounds[i][1]);
    }
    return hi - li + 1;
}