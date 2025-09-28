var s = "pfpfgi";
Console.WriteLine(MajorityFrequencyGroup(s));

string MajorityFrequencyGroup(string s)
{
    var freq = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var counts = freq.Values.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    int max = 0, cur = int.MaxValue;
    foreach (var count in counts.Keys)
    {
        if (counts[count] < max) continue;
        if (counts[count] > max)
            cur = count;
        else if (count > cur)
            cur = count;
        max = counts[count];
    }
    return string.Join("", freq.Where(x => x.Value == cur).Select(x => x.Key));
}