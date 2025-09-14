int EarliestTime(int[][] tasks)
{
    var res = int.MaxValue;
    foreach (var task in tasks)
        res = Math.Min(res, task[0] + task[1]);
    return res;
}