

int CountDays(int days, int[][] meetings)
{
    Array.Sort(meetings, (a, b) => a[0] - b[0]);
    int hi = meetings[0][1], res = meetings[0][0] - 1;
    foreach (var meeting in meetings)
    {
        if (meeting[0] > hi)
            res += meeting[0] - hi - 1;
        hi = Math.Max(hi, meeting[1]);
    }
    return res + days - hi;
}