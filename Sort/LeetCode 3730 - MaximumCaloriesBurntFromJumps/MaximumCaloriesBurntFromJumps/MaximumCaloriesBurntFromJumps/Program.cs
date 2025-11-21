long MaxCaloriesBurnt(int[] heights)
{
    Array.Sort(heights);
    var res = (long)heights[^1] * heights[^1];
    int li = 0, hi = heights.Length - 1, count = 0;
    while (li < hi)
    {
        res += ((long)heights[hi] - heights[li]) * ((long)heights[hi] - heights[li]);
        if (count % 2 == 0)
            hi--;
        else
            li++;
        count++;
    }
    return res;
}