double MaxPrice(int[][] items, int capacity)
{
    items = items.OrderByDescending(x => (double)x[0] / x[1]).ToArray();
    double res = 0;
    for (int i = 0; i < items.Length && capacity > 0; i++)
    {
        var weight = Math.Min(items[i][1], capacity);
        res += (double)items[i][0] / items[i][1] * weight;
        capacity -= weight;
    }
    return capacity == 0 ? res : -1;
}
