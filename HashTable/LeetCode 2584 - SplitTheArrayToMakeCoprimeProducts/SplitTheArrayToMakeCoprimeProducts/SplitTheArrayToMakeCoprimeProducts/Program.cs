int[] nums = { 4, 7, 8, 15, 3, 5 };
Console.WriteLine(FindValidSplit(nums));

int FindValidSplit(int[] nums)
{
    var rightMost = new Dictionary<int, int>();
    var record = new HashSet<int>[nums.Length];
    var right = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var factors = GetFactors(nums[i]);
        foreach (var factor in factors)
            rightMost[factor] = i;
        record[i] = factors;
    }
    for (int i = 0; i < record.Length - 1; i++)
    {
        right = Math.Max(right, record[i].Max(x => rightMost[x]));
        if (i != right) continue;
        return i;
    }
    return -1;
}

HashSet<int> GetFactors(int num)
{
    var factors = new HashSet<int>();
    for (int i = 1; i <= Math.Sqrt(num); i++)
    {
        if (num % i != 0) continue;
        if (i != 1)
            factors.Add(i);
        factors.Add(num / i);
    }
    return factors;
}