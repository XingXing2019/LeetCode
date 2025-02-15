int MaxStudentsOnBench(int[][] students)
{
    if (students.Length == 0) return 0;
    var dict = new Dictionary<int, HashSet<int>>();
    foreach (var s in students)
    {
        if (!dict.ContainsKey(s[1]))
            dict[s[1]] = new HashSet<int>();
        dict[s[1]].Add(s[0]);
    }
    return dict.Max(x => x.Value.Count);
}