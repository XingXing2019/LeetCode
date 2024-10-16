int[][] intervals = new int[][]
{
    new[] { 7, 7 },
    new[] { 17, 19 },
    new[] { 4, 5 },
    new[] { 3, 7 },
    new[] { 15, 15 }
};
var k = 5;
Console.WriteLine(MinConnectedGroups(intervals, k));

int MinConnectedGroups(int[][] intervals, int k)
{
    intervals = intervals.OrderBy(x => x[0]).ToArray();
    var dp = new int[intervals.Length];
    dp[0] = 1;
    var max = intervals[0][1];
    for (int i = 1; i < intervals.Length; i++)
    {
        dp[i] = intervals[i][0] <= max ? dp[i - 1] : dp[i - 1] + 1;
        max = intervals[i][0] <= max ? Math.Max(max, intervals[i][1]) : intervals[i][1];
    }
    var newIntervals = new List<int[]>();
    int res = 0, li = intervals[0][0], hi = intervals[0][1];
    for (int i = 1; i < dp.Length; i++)
    {
        if (dp[i] == dp[i - 1])
            hi = Math.Max(hi, intervals[i][1]);
        else
        {
            newIntervals.Add(new[] { li, hi });
            li = intervals[i][0];
            hi = intervals[i][1];
        }
    }
    newIntervals.Add(new[] { li, hi });
    for (int i = 0; i < newIntervals.Count; i++)
    {
        var index = BinarySearch(newIntervals, newIntervals[i][1] + k);
        res = Math.Max(res, index - i + 1);
    }
    return newIntervals.Count - res + 1;
}

int BinarySearch(List<int[]> intervals, int target)
{
    int li = 0, hi = intervals.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (intervals[mid][0] <= target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}