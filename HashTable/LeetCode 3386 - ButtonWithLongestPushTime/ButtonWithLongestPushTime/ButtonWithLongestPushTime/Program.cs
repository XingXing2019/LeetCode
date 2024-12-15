int ButtonWithLongestTime(int[][] events)
{
    var dict = new Dictionary<int, int>();
    int res = events[0][0], max = events[0][1];
    for (int i = 0; i < events.Length; i++)
    {
        var time = i == 0 ? events[i][1] : events[i][1] - events[i - 1][1];
        var index = events[i][0];
        dict[index] = Math.Max(dict.GetValueOrDefault(index, 0), time);
        if (dict[index] > max)
        {
            res = index;
            max = dict[index];
        }
        if (dict[index] == max && index < res)
            res = index;
    }
    return res;
}