int MinProcessingTime(IList<int> processorTime, IList<int> tasks)
{
    processorTime = processorTime.OrderBy(x => x).ToList();
    tasks = tasks.OrderByDescending(x => x).ToList();
    var res = 0;
    for (int i = 0; i < tasks.Count; i++)
        res = Math.Max(res, tasks[i] + processorTime[i / 4]);
    return res;
}