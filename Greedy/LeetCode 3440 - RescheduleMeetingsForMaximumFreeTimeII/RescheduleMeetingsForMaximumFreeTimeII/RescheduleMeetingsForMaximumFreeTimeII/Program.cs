var eventTime = 50;
int[] startTime = { 9, 24, 45 };
int[] endTime = { 15, 26, 50 };
Console.WriteLine(MaxFreeTime(eventTime, startTime, endTime));

int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
{
    var meetings = new List<int>();
    var gaps = new List<int>();
    var end = 0;
    for (int i = 0; i < startTime.Length; i++)
    {
        var gap = startTime[i] - end;
        gaps.Add(gap);
        end = endTime[i];
        var meeting = endTime[i] - startTime[i];
        meetings.Add(meeting);
    }
    gaps.Add(eventTime - end);
    var left = new int[gaps.Count];
    var right = new int[gaps.Count];
    int leftMax = 0, rightMax = 0;
    for (int i = 0; i < gaps.Count; i++)
    {
        leftMax = Math.Max(leftMax, gaps[i]);
        left[i] = leftMax;
        rightMax = Math.Max(rightMax, gaps[^(i + 1)]);
        right[^(i + 1)] = rightMax;
    }
    var res = 0;
    for (int i = 0; i < meetings.Count; i++)
    {
        var op1 = gaps[i] + gaps[i + 1];
        var op2 = 0;
        if (i != 0 && meetings[i] <= left[i - 1] || meetings[i] <= right[i + 1])
            op2 = gaps[i] + gaps[i + 1] + meetings[i];
        res = Math.Max(res, Math.Max(op1, op2));
    }
    return res;
}

// 9, 9, 19, 0
//   6, 2, 5

// 0,  9,  9, 10
// 19, 19, 0, 0