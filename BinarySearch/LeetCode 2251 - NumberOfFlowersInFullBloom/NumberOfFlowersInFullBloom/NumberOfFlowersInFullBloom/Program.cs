var flowers = new int[][]
{
    new[] { 1, 6 },
    new[] { 3, 7 },
    new[] { 9, 12 },
    new[] { 4, 13 },
};
int[] persons = { 7 };
Console.WriteLine(FullBloomFlowers(flowers, persons));

int[] FullBloomFlowers(int[][] flowers, int[] persons)
{
    var dict = new Dictionary<int, int>();
    foreach (var flower in flowers)
    {
        if (!dict.ContainsKey(flower[0]))
            dict[flower[0]] = 0;
        dict[flower[0]]++;
        if (!dict.ContainsKey(flower[1] + 1))
            dict[flower[1] + 1] = 0;
        dict[flower[1] + 1]--;
    }
    dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    var count = 0;
    var blooms = dict.Select(x =>
    {
        count += x.Value;
        return new[] { x.Key, count };
    }).ToList();
    return persons.Select(x => CountBlooms(blooms, x)).ToArray();
}

int CountBlooms(List<int[]> blooms, int arrive)
{
    int li = 0, hi = blooms.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (blooms[mid][0] == arrive)
            return blooms[mid][1];
        if (blooms[mid][0] > arrive)
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return hi < 0 || hi == blooms.Count - 1 ? 0 : blooms[hi][1];
}