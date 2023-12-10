int CountTestedDevices(int[] batteryPercentages)
{
    var res = 0;
    foreach (var battery in batteryPercentages)
    {
        if (battery - res <= 0) 
            continue;
        res++;
    }
    return res;
}