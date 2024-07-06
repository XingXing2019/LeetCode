int[] colors = { 0, 1, 0, 0, 1, 0, 1 };
var k = 6;
Console.WriteLine(NumberOfAlternatingGroups(colors, k));

int NumberOfAlternatingGroups(int[] colors, int k)
{
    var indexes = new List<int>();
    for (int i = 0; i < colors.Length; i++)
    {
        var next = colors[(i + 1) % colors.Length];
        if (colors[i] != next) continue;
        indexes.Add(i);
    }
    var res = 0;
    if (indexes.Count == 0) res = colors.Length;
    for (int i = 0; i < indexes.Count; i++)
    {
        int cur = indexes[i], next = indexes[(i + 1) % indexes.Count];
        var dis = next <= cur ? next + colors.Length - cur : next - cur;
        res += Math.Max(0, dis - k + 1);
    }
    return res;
}