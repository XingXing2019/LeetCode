IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
{
    var dict = new Dictionary<string, List<int>>();
    foreach (var accessTime in access_times)
    {
        if (!dict.ContainsKey(accessTime[0]))
            dict[accessTime[0]] = new List<int>();
        var hour = int.Parse(accessTime[1].Substring(0, 2));
        var min = int.Parse(accessTime[1].Substring(2));
        dict[accessTime[0]].Add(hour * 60 + min);
    }
    var res = new List<string>();
    foreach (var employee in dict.Keys)
    {
        if (!IsHighAccess(dict[employee])) continue;
        res.Add(employee);
    }
    return res;
}

bool IsHighAccess(List<int> times)
{
    for (int i = 0; i <= times.Count - 3; i++)
    {
        if (times[i + 2] - times[i] >= 60) continue;
        return true;
    }
    return false;
}