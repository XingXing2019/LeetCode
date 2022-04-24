// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IList<int> Intersection(int[][] nums)
{
    var dict = new Dictionary<int, int>();
    foreach (var num in nums)
    {
        foreach (var item in num)
        {
            if (!dict.ContainsKey(item))
                dict[item] = 0;
            dict[item]++;
        }
    }
    return dict.Where(x => x.Value == nums.Length).Select(x => x.Key).OrderBy(x => x).ToList();
}