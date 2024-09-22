long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
{
    long li = 0, hi = (long)workerTimes.Min() * (1 + mountainHeight) * mountainHeight / 2;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (IsSufficient(mountainHeight, workerTimes, mid))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li;
}

bool IsSufficient(int mountainHeight, int[] workerTimes, long sec)
{
    var sum = 0;
    foreach (var worker in workerTimes)
        sum += ((int)Math.Sqrt(8 * sec / worker + 1) - 1) / 2;
    return sum >= mountainHeight;
}