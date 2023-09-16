int[][] coordinates = new int[][]
{
    new[] { 1, 2 },
    new[] { 4, 2 },
    new[] { 1, 3 },
    new[] { 5, 2 },
};
var k = 5;
Console.WriteLine(CountPairs(coordinates, k));


int CountPairs(IList<IList<int>> coordinates, int k)
{
    var dict = new Dictionary<int, Dictionary<int, int>>();
    foreach (var c in coordinates)
    {
        if (!dict.ContainsKey(c[0]))
            dict[c[0]] = new Dictionary<int, int>();
        if (!dict[c[0]].ContainsKey(c[1]))
            dict[c[0]][c[1]] = 0;
        dict[c[0]][c[1]]++;
    }
    long res = 0;
    for (int i = 0; i <= k; i++)
    {
        foreach (var c in coordinates)
        {
            int x = c[0], y = c[1];
            if (!dict.ContainsKey(i ^ x)) continue;
            if (!dict[i ^ x].ContainsKey((k - i) ^ y)) continue;
            res += dict[i ^ x][(k - i) ^ y];
            if (k == 0) res--;
        }
    }
    return (int)(res / 2);
}