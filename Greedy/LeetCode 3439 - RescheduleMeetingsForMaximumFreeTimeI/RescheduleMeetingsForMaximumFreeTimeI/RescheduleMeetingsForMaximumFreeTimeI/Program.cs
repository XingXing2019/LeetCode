int eventTime = 83, k = 1;
int[] startTime = { 13, 15, 43, 81 }, endTime = { 15, 22, 78, 83 };
Console.WriteLine(MaxFreeTime(eventTime, k, startTime, endTime));
int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
{
    var meetings = new List<int[]> { new[] { 0, 0 }, new[] { eventTime, eventTime } };
    for (int i = 0; i < startTime.Length; i++)
        meetings.Add(new[] { startTime[i], endTime[i] });
    meetings.Sort((a, b) => a[0] - b[0]);
    var gaps = new List<int>();
    for (int i = 1; i < meetings.Count; i++)
        gaps.Add(meetings[i][0] - meetings[i - 1][1]);
    var free = 0;
    for (int i = 0; i < Math.Min(k + 1, gaps.Count); i++)
        free += gaps[i];
    var res = free;
    for (int i = k + 1; i < gaps.Count; i++)
    {
        free += gaps[i];
        free -= gaps[i - k - 1];
        res = Math.Max(res, free);
    }
    return res;
}