int eventTime = 5, k = 2;
int[] startTime = { 0, 1, 2, 3, 4 }, endTime = { 1, 2, 3, 4, 5 };
Console.WriteLine(MaxFreeTime(eventTime, k, startTime, endTime));
int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
{
    var meetings = new int[startTime.Length][];
    for (int i = 0; i < meetings.Length; i++)
        meetings[i] = new[] { startTime[i], endTime[i] };
    Array.Sort(meetings, (a, b) => a[0] - b[0]);
    var res = meetings[0][0];
    var hi = 0;
    for (int i = 0; i < meetings.Length; i++)
    {
        res = Math.Max(res, meetings[i][0] - hi);
        if (k != 0 && meetings[i][0] != hi)
        {
            k--;
            hi += meetings[i][1] - meetings[i][0];
        }
        else
            hi = meetings[i][1];
    }
    return Math.Max(res, eventTime - hi);
}