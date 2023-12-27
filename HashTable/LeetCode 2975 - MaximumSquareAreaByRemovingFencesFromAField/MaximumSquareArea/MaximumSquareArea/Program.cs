int m = 6, n = 7;
int[] hFences = { 2 };
int[] vFences = { 4 };
Console.WriteLine(MaximizeSquareArea(m, n, hFences, vFences));

int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
{
    hFences = hFences.Concat(new[] { 1, m }).Order().ToArray();
    vFences = vFences.Concat(new[] { 1, n }).Order().ToArray();
    var set = new HashSet<long>();
    long max = 0, mod = 1_000_000_000 + 7;
    for (int i = 0; i < hFences.Length; i++)
    {
        for (int j = i + 1; j < hFences.Length; j++)
        {
            set.Add(hFences[j] - hFences[i]);
        }
    }
    for (int i = 0; i < vFences.Length; i++)
    {
        for (int j = i + 1; j < vFences.Length; j++)
        {
            if (set.Contains(vFences[j] - vFences[i]))
                max = Math.Max(max, (vFences[j] - vFences[i]) * (vFences[j] - vFences[i]));
        }   
    }
    return (int)(max % mod);
}