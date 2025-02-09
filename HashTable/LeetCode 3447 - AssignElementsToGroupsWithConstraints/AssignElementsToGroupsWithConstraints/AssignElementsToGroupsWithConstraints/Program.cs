int[] groups = { 8, 4, 3, 2, 4 };
int[] elements = { 4, 2 };
Console.WriteLine(AssignElements(groups, elements));

int[] AssignElements(int[] groups, int[] elements)
{
    var index = new Dictionary<int, int>();
    for (int i = 0; i < elements.Length; i++)
    {
        if (index.ContainsKey(elements[i])) continue;
        index[elements[i]] = i;
    }
    var res = new int[groups.Length];
    Array.Fill(res, -1);
    for (int i = 0; i < groups.Length; i++)
    {
        var min = int.MaxValue;
        for (int j = 1; j <= Math.Sqrt(groups[i]); j++)
        {
            if (groups[i] % j != 0) continue;
            if (index.ContainsKey(j))
                min = Math.Min(min, index[j]);
            if (index.ContainsKey(groups[i] / j))
                min = Math.Min(min, index[groups[i] / j]);
        }
        if (min == int.MaxValue) continue;
        res[i] = min;
    }
    return res;
}