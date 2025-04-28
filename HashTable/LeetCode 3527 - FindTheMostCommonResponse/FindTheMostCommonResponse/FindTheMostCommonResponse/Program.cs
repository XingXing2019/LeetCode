string FindCommonResponse(IList<IList<string>> responses)
{
    var dict = new Dictionary<string, int>();
    var res = "";
    var freq = 0;
    foreach (var response in responses)
    {
        var set = new HashSet<string>(response);
        foreach (var r in set)
        {
            if (!dict.ContainsKey(r))
                dict[r] = 0;
            dict[r]++;
            if (dict[r] >= freq)
            {
                if (dict[r] > freq || res.CompareTo(r) > 0)
                    res = r;
                freq = dict[r];
            }
        }
    }
    return res;
}