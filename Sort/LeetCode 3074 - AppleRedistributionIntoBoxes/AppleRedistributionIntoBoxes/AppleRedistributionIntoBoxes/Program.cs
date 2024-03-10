int MinimumBoxes(int[] apple, int[] capacity)
{
    var sum = apple.Sum();
    Array.Sort(capacity, (a, b) => b - a);
    var res = 0;
    foreach (var c in capacity)
    {
        sum -= c;
        res++;
        if (sum <= 0)
            return res;
    }
    return -1;
}