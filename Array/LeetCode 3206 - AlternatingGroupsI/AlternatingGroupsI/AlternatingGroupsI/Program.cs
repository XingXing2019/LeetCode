int NumberOfAlternatingGroups(int[] colors)
{
    var res = 0;
    for (int i = 0; i < colors.Length; i++)
    {
        var first = colors[i];
        var second = colors[(i + 1) % colors.Length];
        var third = colors[(i + 2) % colors.Length];
        if (first != second && second != third)
            res++;
    }
    return res;
}