int MaxPotholes(string road, int budget)
{
    var res = 0;
    var potholes = road.Split('.', StringSplitOptions.RemoveEmptyEntries).OrderByDescending(x => x.Length);
    foreach (var pothole in potholes)
    {
        if (budget <= 0)
            break;
        res += pothole.Length + 1 <= budget ? pothole.Length : budget - 1;
        budget -= Math.Min(budget, pothole.Length + 1);
    }
    return res;
}